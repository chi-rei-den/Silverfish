

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_705",
  "name": [
    "骨魇",
    "Bonemare"
  ],
  "text": [
    "<b>战吼：</b>使一个友方随从获得+4/+4和<b>嘲讽</b>。",
    "<b>Battlecry:</b> Give a friendly minion +4/+4 and <b>Taunt</b>."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 8,
  "rarity": "COMMON",
  "set": "ICECROWN",
  "collectible": true,
  "dbfId": 42790
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_705 : SimTemplate //* Bonemare
    {
        // Battlecry: Give a friendly minion +4/+4 and Taunt.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (target != null)
            {
                p.minionGetBuffed(target, 4, 4);
                if (!target.taunt)
                {
                    target.taunt = true;
                    if (target.own)
                    {
                        p.anzOwnTaunt++;
                    }
                    else
                    {
                        p.anzEnemyTaunt++;
                    }
                }
            }
        }
    }
}