using Chireiden.Silverfish;

/* _BEGIN_TEMPLATE_
{
  "id": "GVG_040",
  "name": [
    "沙鳞灵魂行者",
    "Siltfin Spiritwalker"
  ],
  "text": [
    "每当有其他友方鱼人死亡，便抽一张牌。\n<b>过载：</b>（1）",
    "Whenever another friendly Murloc dies, draw a card. <b><b>Overload</b>:</b> (1)"
  ],
  "cardClass": "SHAMAN",
  "type": "MINION",
  "cost": 4,
  "rarity": "EPIC",
  "set": "GVG",
  "collectible": true,
  "dbfId": 2008
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_GVG_040 : SimTemplate //* Siltfin Spiritwalker
    {
//    Whenever another friendly Murloc dies, draw a card. Overload: (1)

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (own.own)
            {
                p.ueberladung++;
            }
        }

        public override void onMinionDiedTrigger(Playfield p, Minion m, Minion diedMinion)
        {
            var diedMinions = m.own ? p.tempTrigger.ownMurlocDied : p.tempTrigger.enemyMurlocDied;
            if (diedMinions == 0)
            {
                return;
            }

            var residual = p.pID == m.pID ? diedMinions - m.extraParam2 : diedMinions;
            m.pID = p.pID;
            m.extraParam2 = diedMinions;
            for (var i = 0; i < residual; i++)
            {
                p.drawACard(SimCard.None, m.own);
            }
        }
    }
}