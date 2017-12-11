# Project has been moved
This project has been moved in the [ForEvolve-Framework](https://github.com/ForEvolve/ForEvolve-Framework) repository.

# Dynamic InternalServerError
A dynamic internal server error filter for ASP.NET Core, targetting NetStandard 1.6 and Asp.Net Core 2.0, that translate Exceptions (status code 500) to JSON automatically.

Validation errors are also translated automatically, following the same convention, for response with status code 400.

[![forevolve MyGet Build Status](https://www.myget.org/BuildSource/Badge/forevolve?identifier=a6353d8a-cc43-4e21-b226-c2ca715205ab)](https://www.myget.org/)

The error model is based on: [Microsoft REST API Guidelines](https://github.com/Microsoft/api-guidelines/blob/vNext/Guidelines.md#7102-error-condition-responses).

*This is a work in progress.*

ForEvolve [NuGet V3 feed URL](https://www.myget.org/F/forevolve/api/v3/index.json) packages source. See the [Table of content](https://github.com/ForEvolve/Toc) project for more info.

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

## How to add Swagger support
In the `ConfigureServices` method, you must add `services.AddDynamicInternalServerErrorSwagger();`.
In the `services.AddSwaggerGen(c => { ... })` you must register swagger operation filters by calling `c.AddDynamicInternalServerError();`.

```CSharp
public void ConfigureServices(IServiceCollection services)
{
    // Add DynamicInternalServerError
    services.AddDynamicInternalServerError();
    services.AddDynamicInternalServerErrorSwagger();

    // Add framework services.
    services.AddMvc(options =>
    {
        options.ConfigureDynamicInternalServerError();
    });
    
    // Add and configure Swagger.
    services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });

        // Add and configure DynamicInternalServerError.
        c.AddDynamicInternalServerError();
    });
}
```

## Dynamic Validation
`DynamicValidationActionFilter` translates `BadRequestObjectResult` that has a value of type `SerializableError` to an `ErrorResponse` object, following the same convention as `DynamicValidationActionFilter` do. 

### How to use
By default, by registering `DynamicInternalServerError` you also register `DynamicValidation`.
Return `BadRequest(ModelState);` in a controller action. To define `ErrorResponse` automatically in the swagger definition file, simply decorat the action with `[ProducesResponseType(400)]` (do not specify a type).

```CSharp
[HttpPost]
[ProducesResponseType(400)]
public IActionResult Post([FromBody]string value)
{
    if(!ModelState.IsValid)
    {
        return BadRequest(ModelState);
    }
    // ...
}
```
