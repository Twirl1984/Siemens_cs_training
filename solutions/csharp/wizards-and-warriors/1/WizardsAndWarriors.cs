abstract class Character
{
    protected string _characterType;
    
    protected Character(string characterType)
    {
            _characterType=characterType;
    }

    public abstract int DamagePoints(Character target);

    public virtual bool Vulnerable()
    {
        return false;
    }

    public override string ToString()
    {
        return $"Character is a {_characterType}";
    }
}

class Warrior : Character
{
    public Warrior() : base("Warrior")
    {
    }

    public override int DamagePoints(Character target)
    {
         if(target.Vulnerable()==true)
             return 10;
         else
            return 6;
    }
}

class Wizard : Character
{
    protected bool _preparedSpell=false;

    public Wizard() : base("Wizard")
    {
    }

    public override int DamagePoints(Character target)
    {
         if(_preparedSpell==true)
             return 12;
         else
            return 3;
    }

    public void PrepareSpell()
    {
        _preparedSpell=true;
    }

    public override bool Vulnerable()
    {
        return !_preparedSpell;
    }
}
