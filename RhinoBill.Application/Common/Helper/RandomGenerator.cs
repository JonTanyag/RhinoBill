namespace RhinoBill.Application;

public class RandomGenerator
{
    public int GenerateId()
    {
        Random r = new Random();
        int rInt = r.Next(1000, 9999);
        return rInt;
    }
}
