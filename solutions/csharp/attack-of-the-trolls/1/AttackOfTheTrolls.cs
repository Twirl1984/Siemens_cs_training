// TODO: define the 'AccountType' enum
enum AccountType
{
    Guest=0,
    User=1,
    Moderator=2
}
// TODO: define the 'Permission' enum
[Flags]
enum Permission
{
    None=0,
    Read=1,
    Write=2,
    Delete=4,
    All=7
}
static class Permissions
{
    public static Permission Default(AccountType accountType)
    {
        switch (accountType)
        {
            case AccountType.Guest: 
            return Permission.Read; 
            break;
            case AccountType.User: 
            return Permission.Read | Permission.Write; 
            break;
            case AccountType.Moderator: 
            return Permission.Read | Permission.Write | Permission.Delete;                                      break;            
            default:
            Console.WriteLine("The Account Type is not valid.");
            return Permission.None;
            break;
        }
    }

    public static Permission Grant(Permission current, Permission grant)
    {
        return current | grant;
    }

    public static Permission Revoke(Permission current, Permission revoke)
    {
        return current &~revoke;
    }

    public static bool Check(Permission current, Permission check)
    {
        return current>=check;
    }
}
