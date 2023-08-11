using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using SkiaSharp;
using System.Collections.Generic;

namespace Medical_Rgistrations
{
    public class GenericController
    {

        //public class TranslationTransformer : DynamicRouteValueTransformer
        //{
        //    private readonly TranslationDatabase _translationDatabase;

        //    public TranslationTransformer(TranslationDatabase translationDatabase)
        //    {
        //        _translationDatabase = translationDatabase;
        //    }

        //    public override async ValueTask<RouteValueDictionary> TransformAsync(HttpContext httpContext, RouteValueDictionary values)
        //    {
        //        if (!values.ContainsKey("language") || !values.ContainsKey("controller") || !values.ContainsKey("action")) return values;

        //        var language = (string)values["language"];
        //        var controller = await _translationDatabase.Resolve(language, (string)values["controller"]);
        //        if (controller == null) return values;
        //        values["controller"] = controller;

        //        var action = await _translationDatabase.Resolve(language, (string)values["action"]);
        //        if (action == null) return values;
        //        values["action"] = action;

        //        return values;
        //    }
        //}
    }
}
