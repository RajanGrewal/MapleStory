namespace Dango.MapleStory.Enums
{
    /// <summary>
    /// TODO: 应该是用来记录登陆状态的
    /// </summary>
    public enum LogInState : byte
    {
        NotLogIn,
        WaitingForDetail,
        ServerTransition,
        LoggedIn,
        Waiting,
        ViewAllCharacter
    }
}