

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_961",
  "name": [
    "适者生存",
    "Adaptation"
  ],
  "text": [
    "<b>进化</b>一个友方随从。",
    "<b>Adapt</b> a friendly minion."
  ],
  "cardClass": "PALADIN",
  "type": "SPELL",
  "cost": 1,
  "rarity": "COMMON",
  "set": "UNGORO",
  "collectible": true,
  "dbfId": 41944
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_UNG_961 : SimTemplate //* Adaptation
    {
        //Adapt a friendly minion.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.evaluatePenality -= 15;
        }
    }
}