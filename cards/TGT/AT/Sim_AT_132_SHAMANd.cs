

/* _BEGIN_TEMPLATE_
{
  "id": "AT_132_SHAMANd",
  "name": [
    "空气之怒图腾",
    "Wrath of Air Totem"
  ],
  "text": [
    "<b>法术伤害+1</b>",
    "<b>Spell Damage +1</b>"
  ],
  "cardClass": "SHAMAN",
  "type": "MINION",
  "cost": 1,
  "rarity": null,
  "set": "TGT",
  "collectible": null,
  "dbfId": 16225
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_AT_132_SHAMANd : SimTemplate //* Wrath of Air Totem
    {
        //Spell Damage +1

        public override void onAuraStarts(Playfield p, Minion m)
        {
            if (m.own)
            {
                p.spellpower++;
            }
            else
            {
                p.enemyspellpower++;
            }
        }


        public override void onAuraEnds(Playfield p, Minion m)
        {
            if (m.own)
            {
                p.spellpower--;
            }
            else
            {
                p.enemyspellpower--;
            }
        }
    }
}