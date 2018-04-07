# What is "Template"?

Templates are ASP.NET (Dotnet) Core source files used to generate the pages requested by visitors, and are output as HTML. Template files are made up of HTML, ASP.NET (Dotnet) Core, and SIOC CMS Template Tags.

Let's look at the various templates that can be defined as part of a Theme.

SIOC CMS allows you to define separate templates for the various aspects of your site. It is not essential, however, to have all these different template files for your site to fully function. Templates are chosen and generated based upon the Template Hierarchy, depending upon what templates are available in a particular Theme.

As a Theme developer, you can choose the amount of customization you want to implement using templates. For example, as an extreme case, you can use only one template file, called index.aspx as the template for all pages generated and displayed by the site. A more common use is to have different template files generate different results, to allow maximum customization.

# Template Files List

(TBC)

# Basic Templates

(TBC)

# Custom Page Templates

(TBC)

# Custom Module Templates

(TBC)

# Translation Support / I18n

To ensure smooth transition for language localization, use the SIOC CMS gettext-based i18n functions for wrapping all translatable text within the template files. This makes it easier for the translation files to hook in and translate the labels, titles and other template text into the site's current language. See more at SIOC CMS Localization and I18n for SIOC CMS Developers.

# Template File Checklist

When developing a Theme, check your template files against the following template file standards.

## Document Head (header.aspx)

- Use the proper [DOCTYPE](https://en.wikipedia.org/wiki/Document_Type_Declaration).
- The opening `<html>` tag should include language attributes. **[TODO]**
- The `<meta>` charset element should be placed before everything else, including the `<title>` element.
- Use `@metainfo()` to set the `<meta>` charset and description elements. **[TODO]**
- Use `@ViewData["Title"]` to set the `<title>` element.
- Use Automatic Feed Links to add feed links. 
- Add a call to `@Html.Partial("../Layouts/sioc_head.cshtml")` before the closing `</head>` tag. Plugins use this action hook to add their own scripts, stylesheets, and other functionality.
- Do not link the theme stylesheets in the Header template. Use the `@RenderSection("Styles", false)` action hook in a theme function instead.

Here's an example of a correctly-formatted HTML5 compliant head area:

```aspx
<!DOCTYPE html>
<html lang="en">
    <head>
        <meta charset="..." />
        <title>@ViewData["Title"] - Swastika I/O</title>
        <link rel="profile" href="http://gmpg.org/xfn/11" />
        ...
    </head>
```

