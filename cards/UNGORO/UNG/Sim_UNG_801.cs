

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_801",
  "name": [
    "筑巢双头鹏",
    "Nesting Roc"
  ],
  "text": [
    "<b>战吼：</b>如果你控制至少两个其他随从，便获得<b>嘲讽</b>。",
    "<b>Battlecry:</b> If you control at least 2 other minions, gain <b>Taunt</b>."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 5,
  "rarity": "COMMON",
  "set": "UNGORO",
  "collectible": true,
  "dbfId": 41305
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_UNG_801 : SimTemplate //* Nesting Roc
    {
        //Battlecry: If you control at least 2 other minions, gain Taunt.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            var num = own.own ? p.ownMinions.Count : p.enemyMinions.Count;
            if (num > 1)
            {
                own.taunt = true;
                if (own.own)
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