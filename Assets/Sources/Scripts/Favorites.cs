using System.Collections.Generic;
using UnityEngine;

public class Favorites
{
    private List<int> _numbers = new List<int>();

    public List<int> Numbers => _numbers;

    public void Load()
    {
        if (!PlayerPrefs.HasKey("title"))
            return;


        string[] array = PlayerPrefs.GetString("title").Split(" ");
        foreach (string item in array)
        {
            Debug.Log(item);
            _numbers.Add(int.Parse(item));

        }

    }

    public void Add(int number)
    {
        if (_numbers.Contains(number))
            return;

        _numbers.Add(number);

        PlayerPrefs.SetString("title", string.Join(" ", _numbers));
        Debug.Log(PlayerPrefs.GetString("title").Split(" "));
    }

    //public List<int> GetFavorites()
    //{
    //    var array = PlayerPrefs.GetString("title").Split(';');
    //    List<int> numbers = new List<int>();

    //    foreach (var item in array)
    //    {
    //        numbers.Add(int.Parse(item));
    //    }

    //    return _numbers;
    //}
}
