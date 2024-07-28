## RhinoBill


*TechStack*
- .NET 8
- EF Core 8 (InMemory database)
- Mediatr
- FluentValidation
- NUnit & Shouldly

**Setup**
``` bash
git clone <repository-url>
cd <repository-folder>
dotnet clean
dotnet build

dotnet run
```

API Endpoints
Students
``` bash
GET /api/students: Retrieves a list of students.
GET /api/students/{id}: Retrieves a specific student by ID.
POST /api/students: Creates a new student.
PUT /api/students/{id}: Updates an existing student.
DELETE /api/students/{id}: Deletes a student.
```
Courses
``` bash
GET /api/courses: Retrieves a list of courses.
GET /api/courses/{id}: Retrieves a specific course by ID.
POST /api/courses: Creates a new course.
PUT /api/courses/{id}: Updates an existing course.
DELETE /api/courses/{id}: Deletes a course.
```
Applications
``` bash
GET /api/applications: Retrieves a list of applications.
GET /api/applications/{id}: Retrieves a specific application by ID.
POST /api/applications: Creates a new application.
PUT /api/applications/{id}: Updates an existing application.
DELETE /api/applications/{id}: Deletes an application.
```
Running Test
``` bash
cd <unit-test-project-directory>
dotnet test
```
