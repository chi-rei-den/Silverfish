

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_999t13",
  "name": [
    "毒液喷吐",
    "Poison Spit"
  ],
  "text": [
    "<b>剧毒</b>",
    "<b>Poisonous</b>"
  ],
  "cardClass": "NEUTRAL",
  "type": "SPELL",
  "cost": 0,
  "rarity": null,
  "set": "UNGORO",
  "collectible": null,
  "dbfId": 41211
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_UNG_999t13 : SimTemplate //* Poison Spit
    {
        //Poisonous

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            target.poisonous = true;
        }
    }
}