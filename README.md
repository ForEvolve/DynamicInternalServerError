# DynamicInternalServerError
A dynamic internal server error filter for ASP.NET Core, targetting NetStandard 1.6, that translate Exceptions to JSON automatically.

[![forevolve MyGet Build Status](https://www.myget.org/BuildSource/Badge/forevolve?identifier=f930b44e-be3e-4249-8992-de5ac7bb7e1f)](https://www.myget.org/)

The error model is based on: [Microsoft REST API Guidelines](https://github.com/Microsoft/api-guidelines/blob/vNext/Guidelines.md#7102-error-condition-responses).

*This is a work in progress.*

## How to use
In your `Startup` class, you must `AddDynamicInternalServerError()` to add dependencies and `ConfigureDynamicInternalServerError()` to add the filter to MVC.

```CSharp
public void ConfigureServices(IServiceCollection services)
{
    // Add DynamicInternalServerError
    services.AddDynamicInternalServerError();

    // Add framework services.
    services.AddMvc(options =>
    {
        options.ConfigureDynamicInternalServerError();
    });
}
```

Thats it, now exceptions are translated to JSON.