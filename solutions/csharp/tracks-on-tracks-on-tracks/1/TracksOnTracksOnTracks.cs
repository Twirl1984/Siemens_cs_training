//using System;
//using System.Collections.Generic;
using System.Linq; // Oben hinzufügen



public static class Languages
{
    //var listOfStrings = new List<string>();
    
    public static List<string> NewList() => new List<string>();

    public static List<string> GetExistingLanguages() => ["C#", "Clojure", "Elm"];

    public static List<string> AddLanguage(List<string> languages, string language) =>            [..languages,language];

    public static int CountLanguages(List<string> languages) => languages.Count();    
    

    public static bool HasLanguage(List<string> languages, string language) => languages.Contains(language);
    

    public static List<string> ReverseList(List<string> languages) 
        => languages.AsEnumerable().Reverse().ToList();
    
    public static bool IsExciting(List<string> languages)
    {
        int count=CountLanguages(languages);
        if (count == 0) return false;
        if(languages[0]=="C#") return true;
        if(languages[1]=="C#" && (count==2 || count==3)) return true;      
        return false;
    }

    public static List<string> RemoveLanguage(List<string> languages, string language) => languages.Where(l => l != language).ToList();

    public static bool IsUnique(List<string> languages)=> languages.Distinct().Count()==CountLanguages(languages);
}
