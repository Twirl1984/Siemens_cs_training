public class SecurityPassMaker
{
    public string GetDisplayName(TeamSupport support)
    {
        //throw new NotImplementedException($"Please implement the SecurityPassMaker.GetDisplayName() method");
        //Please implement the `SecurityPassMaker.GetDisplayName()` method. 
        //It should return the value of the `Title` field instances of all classes derived from `Staff` and,
        // otherwise, "Too Important for a Security Pass".


        //```csharp
        //var spm = new SecurityPassMaker();
        //spm.GetDisplayName(new Manager());
        // => "Too Important for a Security Pass"
        //spm.GetDisplayName(new Physio());
        // => "The Physio"
        //o is ICollection<int> // true
        //o.GetType() == typeof(ICollection<int>) // false
        //o is List<int> // true
        //o.GetType() == typeof(List<int>) // true
        if(support is Security && support is not SecurityJunior && support is not  SecurityIntern && support is not PoliceLiaison)
        {
            return support.Title+" Priority Personnel";
        }
        else if(support is Staff)
        {
            return support.Title;
        }
        else
        {
            return "Too Important for a Security Pass";
        }
        
    }
}

/**** Please do not alter the code below ****/

public interface TeamSupport { string Title { get; } }

public abstract class Staff : TeamSupport { public abstract string Title { get; } }

public class Manager : TeamSupport { public string Title { get; } = "The Manager"; }

public class Chairman : TeamSupport { public string Title { get; } = "The Chairman"; }

public class Physio : Staff { public override string Title { get; } = "The Physio"; }

public class OffensiveCoach : Staff { public override string Title { get; } = "Offensive Coach"; }

public class GoalKeepingCoach : Staff { public override string Title { get; } = "Goal Keeping Coach"; }

public class Security : Staff { public override string Title { get; } = "Security Team Member"; }

public class SecurityJunior : Security { public override string Title { get; } = "Security Junior"; }

public class SecurityIntern : Security { public override string Title { get; } = "Security Intern"; }

public class PoliceLiaison : Security { public override string Title { get; } = "Police Liaison Officer"; }
