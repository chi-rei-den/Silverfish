

/* _BEGIN_TEMPLATE_
{
  "id": "CS2_105",
  "name": [
    "英勇打击",
    "Heroic Strike"
  ],
  "text": [
    "在本回合中，使你的英雄获得+4攻击力。",
    "Give your hero +4 Attack this turn."
  ],
  "CardClass": "WARRIOR",
  "type": "SPELL",
  "cost": 2,
  "rarity": "FREE",
  "set": "CORE",
  "collectible": true,
  "dbfId": 1007
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_CS2_105 : SimTemplate //heroicstrike
    {
        //    verleiht eurem helden +4 angriff in diesem zug.
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionGetTempBuff(ownplay ? p.ownHero : p.enemyHero, 4, 0);
        }
    }
}