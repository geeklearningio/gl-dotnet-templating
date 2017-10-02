[![NuGet Version](http://img.shields.io/nuget/v/GeekLearning.Templating.svg?style=flat-square&label=NuGet)](https://www.nuget.org/packages/GeekLearning.Templating/)
[![Build Status](https://geeklearning.visualstudio.com/_apis/public/build/definitions/f841b266-7595-4d01-9ee1-4864cf65aa73/24/badge)](#)

# gl-dotnet-templating

This templating library is an abstraction above various templating engines and our 
[storage library](https://github.com/geeklearningio/gl-dotnet-storage). It handles loading
from any location supported by our storage library. It will also transparently cache templates 
for you. 

It has support for partials, files prefixed with an underscore `_` will be considered as partials
and loaded as such.

## Getting started

In your project.json add required dependencies :
```
"GeekLearning.Storage.FileSystem": "0.5.0",
    
"GeekLearning.Templating": "0.5.0",
"GeekLearning.Templating.Handlebars": "0.5.0",
```

Then add required settings in your `appsettings.json` file. In this example, we will
use FileSystem provider to configure a storage provider which will load files from
a `Templates` folder relative to Application Root. This could be configured to use 
an Azure Container instead (see storage documentation).

```json
"Storage": {
    "Stores": {
      "Templates": {
        "Provider": "FileSystem",
        "Parameters": {
          "Path": "Templates"
        }
      }
    }
  }
```

We will then create an `EmailTemplates` class. It will be based on `TemplateCollectionBase`
which eliminates most of the boilerplate code required to load and execute a template. 

```csharp
public class EmailTemplates : TemplateCollectionBase
{
    public EmailTemplates(IStorageFactory storageFactory, ITemplateLoaderFactory templateLoaderFactory) : base("Templates", storageFactory, templateLoaderFactory)
    {

    }

    public Task<string> ApplyInvitationTemplate(InvitationContext context)
    {
        return this.LoadAndApplyTemplate("invitation", context);
    }

    public Task<string> ApplyInvitation2Template(InvitationContext context)
    {
        return this.LoadAndApplyTemplate("invitation2", context);
    }

    public Task<string> ApplyInvitation3Template(InvitationContext context)
    {
        return this.LoadAndApplyTemplate("SubDir/invitation", context);
    }
}
```

Then in your `Startup.cs` file add required dependencies and configuration to the DI container. 

```csharp
services.AddMemoryCache();
services.AddStorage().AddFileSystemStorage(HostingEnvironment.ContentRootPath).AddAzureStorage();
services.AddTemplating().AddMustache().AddHandlebars();
services.AddScoped<EmailTemplates>();

services.Configure<StorageOptions>(Configuration.GetSection("Storage"));
```

## Templating Abstraction

Our abstraction is composed of a few interface and a base class to reduce boilerplate code when
working with templates.

First interface is `ITemplateLoaderFactory`.

```csharp
public interface ITemplateLoaderFactory
{
    ITemplateLoader Create(IStore store);
}
```

You can use this interface to get an `ITemplateLoader` for a specific `IStore` (see storage documentation)

```csharp
public interface ITemplateLoader
{
    Task<ITemplate> GetTemplate(string name);
}
```

Once you have an `ITemplateLoader` interface you can retrieve a specific template by is name.
If it's not already loaded, it will be read from the `IStore`.

```csharp
public interface ITemplate
{
    string Apply(object context);
}
```

A `ITemplate` reference can be executed on a specific `context` using `Apply` method.

## Handlebars provider

`Handlebars` provider allows you to load `.hbs` templates 
(see [Handlebars.js](http://handlebarsjs.com/)). It relies on Handlebars.Net [port](https://github.com/rexm/Handlebars.Net).

This is our recommanded option as it compiles templates for better performance.

## Mustache.js provider

`Mustache.js` provider is a mustache provider allowing you to load `.mustache` templates. It is based on 
[mustache sharp](https://github.com/jehugaleahsa/mustache-sharp) work. As we've go no answer
from author, we are maintaining dotnet core support on our [own fork](https://github.com/sandorfr/mustache-sharp).

A good thing is it has no dependency on Emit or Expression so it might be usefull on some
edge cases. 

**Note that it does not support partials.**

## Roadmap

* Design and add Helpers support for Handlebars Engine.
* Additional providers (haml through NHAML or NVelocity).