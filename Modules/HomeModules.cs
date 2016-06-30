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
      Get["/guess_result"] = _ => {
        var newGame = new Game(Request.Form["word"]);
        return View["/guess_result.cshtml", newGame];
      };
      Post["/guess_result"] = _ => {
        string userGuess = Request.Form["letter"];
        string wordToGuess = newGame.GetString();
        if (wordToGuess.Contains(userGuess))
        {
          int letterPosition = wordToGuess.IndexOf(userGuess);
          newGame.GetBlanks().Remove(letterPosition, 1);
          newGame.GetBlanks().Insert(letterPosition, userGuess);
        }
        return View["guess_result.cshtml", newGame];
      };
    }
  }
}
