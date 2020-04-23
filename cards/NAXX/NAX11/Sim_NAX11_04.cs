

/* _BEGIN_TEMPLATE_
{
  "id": "NAX11_04",
  "name": [
    "变异注射",
    "Mutating Injection"
  ],
  "text": [
    "使一个随从获得+4/+4和<b>嘲讽</b>。",
    "Give a minion +4/+4 and <b>Taunt</b>."
  ],
  "cardClass": "NEUTRAL",
  "type": "SPELL",
  "cost": 3,
  "rarity": null,
  "set": "NAXX",
  "collectible": null,
  "dbfId": 1925
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_NAX11_04 : SimTemplate //* Mutating Injection
    {
        // Give a minion +4/+4 and Taunt.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
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