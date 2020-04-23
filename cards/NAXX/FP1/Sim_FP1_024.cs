

/* _BEGIN_TEMPLATE_
{
  "id": "FP1_024",
  "name": [
    "蹒跚的食尸鬼",
    "Unstable Ghoul"
  ],
  "text": [
    "<b>嘲讽，亡语：</b>对所有随从造成1点伤害。",
    "<b>Taunt</b>. <b>Deathrattle:</b> Deal 1 damage to all minions."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 2,
  "rarity": "COMMON",
  "set": "NAXX",
  "collectible": true,
  "dbfId": 1808
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_FP1_024 : SimTemplate //unstableghoul
    {
//    spott/. todesröcheln:/ fügt allen dienern 1 schaden zu.

        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.allMinionsGetDamage(1);
        }
    }
}