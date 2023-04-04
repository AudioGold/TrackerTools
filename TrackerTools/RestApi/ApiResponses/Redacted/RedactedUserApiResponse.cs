using TrackerTools.RestApi.Clients;

namespace TrackerTools.RestApi.ApiResponses.Redacted;

public class RedactedUserApiResponse : BaseApiResponse
{
    public UserResponseData Response { get; set; }
}

public class UserResponseData : BaseResponseData
{
    public string Username { get; set; }
    public string Avatar { get; set; }
    public bool IsFriend { get; set; }
    public string ProfileText { get; set; }
    public string BbProfileText { get; set; }
    public ProfileAlbum ProfileAlbum { get; set; }
    public Stats Stats { get; set; }
    public Ranks Ranks { get; set; }
    public Personal Personal { get; set; }
    public Community Community { get; set; }
}

public class ProfileAlbum
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Review { get; set; }
}

public class Ranks
{
    public int Uploaded { get; set; }
    public int Downloaded { get; set; }
    public int Uploads { get; set; }
    public int Requests { get; set; }
    public int Bounty { get; set; }
    public int Posts { get; set; }
    public int Artists { get; set; }
    public int Overall { get; set; }
}

public class Community
{
    public int Posts { get; set; }
    public int TorrentComments { get; set; }
    public int CollagesStarted { get; set; }
    public int CollagesContrib { get; set; }
    public int RequestsFilled { get; set; }
    public int RequestsVoted { get; set; }
    public int PerfectFlacs { get; set; }
    public int Uploaded { get; set; }
    public int Groups { get; set; }
    public int Seeding { get; set; }
    public int Leeching { get; set; }
    public int Snatched { get; set; }
    public int Invited { get; set; }
}

public class Stats
{
    public string JoinedDate { get; set; }
    public string LastAccess { get; set; }
    public long Uploaded { get; set; }
    public long Downloaded { get; set; }
    public double Ratio { get; set; }
    public double RequiredRatio { get; set; }
}

public class Personal
{
    public string Class { get; set; }
    public int Paranoia { get; set; }
    public string ParanoiaText { get; set; }
    public bool Donor { get; set; }
    public bool Warned { get; set; }
    public bool Enabled { get; set; }
    public string Passkey { get; set; }
}