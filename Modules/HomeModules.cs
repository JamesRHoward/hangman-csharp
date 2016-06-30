using Nancy;
using System.Collections.Generic;
using Hangman.Objects;
using System.Text.RegularExpressions;

namespace Hangman
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => {
        return View["index.cshtml"];
      };
      Get["/start"] = _ => {
        return View["start_game.cshtml"];
      };
      Post["/guess"] = _ => {
        var newGame = new Game(Request.Form["word"]);
        return View["guess.cshtml", newGame];
      };
    }
  }
}
