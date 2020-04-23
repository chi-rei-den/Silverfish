

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_295",
  "name": [
    "寒冰屏障",
    "Ice Block"
  ],
  "text": [
    "<b>奥秘：</b>当你的英雄将要承受致命伤害时，防止这些伤害，并使其在本回合中获得<b>免疫</b>。",
    "<b>Secret:</b> When your hero takes fatal damage, prevent it and become <b>Immune</b> this turn."
  ],
  "cardClass": "MAGE",
  "type": "SPELL",
  "cost": 3,
  "rarity": "EPIC",
  "set": "HOF",
  "collectible": true,
  "dbfId": 192
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_EX1_295 : SimTemplate //iceblock
    {
        //todo secret
//    geheimnis:/ wenn euer held tödlichen schaden erleidet, wird dieser verhindert und der held wird immun/ in diesem zug.
        public override void onSecretPlay(Playfield p, bool ownplay, Minion target, int number)
        {
            target.Hp += number;
            target.immune = true;
        }
    }
}