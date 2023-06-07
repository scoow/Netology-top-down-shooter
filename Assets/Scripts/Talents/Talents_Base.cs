
using TDShooter.Configs;
using UnityEngine;
using UnityEngine.UI;

public class Talents_Base
{
    private Player_Data player_Data;
    private Sprite _talentSprite;
    private string _description;    

    public Sprite TalentSprite { get => _talentSprite; protected set => _talentSprite = value; }
    public string Description { get => _description; protected set => _description = value; }
    protected Player_Data Player_Data { get => player_Data; private set => player_Data = value; }

    public Talents_Base(Player_Data player_Data)
    {
        Player_Data = player_Data;
    }

    public virtual void ActivateTalant()
    {

    }    
}