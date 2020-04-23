

/* _BEGIN_TEMPLATE_
{
  "id": "CS2_045",
  "name": [
    "石化武器",
    "Rockbiter Weapon"
  ],
  "text": [
    "在本回合中，使一个友方角色获得+3攻击力。",
    "Give a friendly character +3 Attack this turn."
  ],
  "CardClass": "SHAMAN",
  "type": "SPELL",
  "cost": 2,
  "rarity": "FREE",
  "set": "CORE",
  "collectible": true,
  "dbfId": 239
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_CS2_045 : SimTemplate //rockbiterweapon
    {
//    verleiht einem befreundeten charakter +3 angriff in diesem zug.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionGetTempBuff(target, 3, 0);
        }
    }
}