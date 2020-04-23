using Chireiden.Silverfish;
using HearthDb.Enums;

/* _BEGIN_TEMPLATE_
{
  "id": "LOE_026",
  "name": [
    "亡者归来",
    "Anyfin Can Happen"
  ],
  "text": [
    "召唤七个在本局对战中死亡的\n鱼人。",
    "Summon 7 Murlocs that died this game."
  ],
  "cardClass": "PALADIN",
  "type": "SPELL",
  "cost": 10,
  "rarity": "RARE",
  "set": "LOE",
  "collectible": true,
  "dbfId": 2898
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_LOE_026 : SimTemplate //* Anyfin Can Happen
    {
        //Summon 7 Murlocs that died this game.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            var place = ownplay ? p.ownMinions.Count : p.enemyMinions.Count;
            var temp = ownplay ? Probabilitymaker.Instance.ownCardsOut : Probabilitymaker.Instance.enemyCardsOut;
            if (place > 6)
            {
                return;
            }

            SimCard c;
            foreach (var gi in temp)
            {
                c = gi.Key;
                if (c.Race == Race.MURLOC)
                {
                    p.callKid(c, place, ownplay, false);
                    place++;
                    if (place > 6)
                    {
                        break;
                    }

                    if (gi.Value > 1)
                    {
                        p.callKid(c, place, ownplay, false);
                        place++;
                        if (place > 6)
                        {
                            break;
                        }
                    }
                }
            }

            if (place > 6)
            {
                return;
            }

            foreach (var gi in p.diedMinions)
            {
                if (gi.own == ownplay)
                {
                    c = gi.cardid;
                    if (c.Race == Race.MURLOC)
                    {
                        p.callKid(c, place, ownplay, false);
                        place++;
                        if (place > 6)
                        {
                            break;
                        }
                    }
                }
            }
        }
    }
}