using System.Collections.Generic;
using System.Text.RegularExpressions;


namespace Hangman.Objects
{
  public class Game
  {
    private string _stringToGuess;
    private int _guessCounter;
    private int _guessesMade;
    private bool _win;
    private static List<string> _correctGuesses = new List<string> {};
    private static List<string> _wrongGuesses = new List<string> {};
    private string _blanks;


    //game constructor
    public Game(string stringToGuess)
    {
      _stringToGuess = stringToGuess;
      _blanks = Regex.Replace(stringToGuess, "[a-zA-Z]", "-");
      _guessCounter = 6;
      _guessesMade = 0;
      _win = false;
    }
    //Evalutes a guess. if it's correct it adds it to the correctGuesses list.
    public void evaluateGuess(string guess)
    {
      if (_stringToGuess.ToLower().Contains(guess.ToLower()))
      {
        _correctGuesses.Add(guess);
        _guessesMade++;
      }
      else
      {
        _wrongGuesses.Add(guess);
        _guessCounter--;
        _guessesMade++;
      }
    }
    //Evaluates win condition
    public void evaluateWin()
    {
      if(_stringToGuess.Length == _correctGuesses.Count)
      {
        _win = true;
      }
    }
    public string GetString()
    {
      return _stringToGuess;
    }
    public string GetBlanks()
    {
      return _blanks;
    }

  }
}
