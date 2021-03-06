﻿using Microsoft.AspNetCore.Http;
using Datasilk;

public class Routes: Datasilk.Routes
{
    public override Page FromPageRoutes(HttpContext context, string name)
    {
        switch (name)
        {
            case "": case "home": return new Kandu.Pages.Home(context);
            case "login": return new Kandu.Pages.Login(context);
            case "boards": return new Kandu.Pages.Boards(context);
            case "board": return new Kandu.Pages.Board(context);
            case "import": return new Kandu.Pages.Import(context);
        }
        return null;

    }

    public override Service FromServiceRoutes(HttpContext context, string name)
    {
        return null;
    }
}
