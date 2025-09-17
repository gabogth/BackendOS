using Pulumi;

public class Program
{
    public static async Task<int> Main(string[] args)
    {
        return await Deployment.RunAsync<nest.iac.servicesinfra.Index>();
    }
}