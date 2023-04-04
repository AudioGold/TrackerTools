namespace TrackerTools.RestApi.ApiResponses.Orpheus;

public class OrpheusUserApiResponse : BaseApiResponse
{
    public string Status { get; set; }
    public ResponseData Response { get; set; }
    public Info Info { get; set; }
}

public class ResponseData
{
    public string Username { get; set; }
    public string Avatar { get; set; }
    public bool IsFriend { get; set; }
    public string ProfileText { get; set; }
    public Stats Stats { get; set; }
    public Ranks Ranks { get; set; }
    public Personal Personal { get; set; }
    public Community Community { get; set; }
}

public class Stats
{
    public string JoinedDate { get; set; }
    public string LastAccess { get; set; }
    public long Uploaded { get; set; }
    public long Downloaded { get; set; }
    public double RequiredRatio { get; set; }
    public double Ratio { get; set; }
}

public class Ranks
{
    public int Uploaded { get; set; }
    public int Downloaded { get; set; }
    public int Uploads { get; set; }
    public int Requests { get; set; }
    public int Bounty { get; set; }
    public int Artists { get; set; }
    public int Collage { get; set; }
    public int Posts { get; set; }
    public int Votes { get; set; }
    public int Bonus { get; set; }
    public double Overall { get; set; }
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

public class Community
{
    public int Posts { get; set; }
    public int TorrentComments { get; set; }
    public int CollagesContrib { get; set; }
    public int RequestsFilled { get; set; }
    public int BountyEarned { get; set; }
    public int RequestsVoted { get; set; }
    public int BountySpent { get; set; }
    public int ReleaseVotes { get; set; }
    public int Uploaded { get; set; }
    public int ArtistsAdded { get; set; }
    public int ArtistComments { get; set; }
    public int CollageComments { get; set; }
    public int RequestComments { get; set; }
    public int CollagesStarted { get; set; }
    public int PerfectFlacs { get; set; }
    public int Groups { get; set; }
    public int Seeding { get; set; }
    public int Leeching { get; set; }
    public int Snatched { get; set; }
    public int Invited { get; set; }
}

public class Info
{
    public string Source { get; set; }
    public int Version { get; set; }
}
