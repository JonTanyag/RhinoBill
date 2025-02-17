﻿using MediatR;
using Microsoft.Extensions.Logging;
using RhinoBill.Core;

namespace RhinoBill.Application;

public class AddCourseCommandHandler : IRequestHandler<AddCourseCommand, AddCourseResponse>
{
    private readonly ILogger<AddCourseCommandHandler> _logger;
    private readonly ICourseService _courseService;
    private readonly RandomGenerator _randomGenerator;
    public AddCourseCommandHandler(ICourseService courseService,
        ILogger<AddCourseCommandHandler> logger,
        RandomGenerator randomGenerator)
    {
        _courseService = courseService;
        _randomGenerator = randomGenerator;
        _logger = logger;
    }

    public async Task<AddCourseResponse> Handle(AddCourseCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var course = new Course
            {
                Id = _randomGenerator.GenerateId(),
                Code = request.Course.Code,
                Title = request.Course.Title,
                Credits = request.Course.Credits,
            };
            
            await _courseService.AddCourse(course, cancellationToken);

            _logger.LogInformation(ApiMessage.Add_Course_LogInformation);
            return new AddCourseResponse(true, ApiMessage.Add_Course_LogInformation, 201);
        }
        catch (Exception ex)
        {
            _logger.LogError(ApiMessage.Add_Course_LogError, $"{ex.Message} - {ex.InnerException}");
            return new AddCourseResponse(false, ex.Message, 500);
        }
    }
}
