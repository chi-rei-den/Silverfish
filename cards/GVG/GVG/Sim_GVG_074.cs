using HearthDb;
using HearthDb.Enums;

/* _BEGIN_TEMPLATE_
{
  "id": "GVG_074",
  "name": [
    "科赞秘术师",
    "Kezan Mystic"
  ],
  "text": [
    "<b>战吼：</b>随机获得一个敌方<b>奥秘</b>的控制权。",
    "<b>Battlecry:</b> Take control of a random enemy <b>Secret</b>."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 4,
  "rarity": "RARE",
  "set": "GVG",
  "collectible": true,
  "dbfId": 2042
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_GVG_074 : SimTemplate //Kezan Mystic
    {
        //todo better!
        //  Battlecry: Take control of a random enemy Secret;. 

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (own.own)
            {
                if (p.enemySecretList.Count >= 1)
                {
                    if (p.enemyHeroStartClass == CardClass.HUNTER)
                    {
                        p.ownSecretsIDList.Add(CardIds.Collectible.Hunter.ExplosiveTrap);
                    }

                    if (p.enemyHeroStartClass == CardClass.MAGE)
                    {
                        p.ownSecretsIDList.Add(CardIds.Collectible.Mage.Vaporize);
                    }

                    if (p.enemyHeroStartClass == CardClass.PALADIN)
                    {
                        p.ownSecretsIDList.Add(CardIds.Collectible.Paladin.NobleSacrifice);
                    }

                    if (p.enemyHeroStartClass != CardClass.HUNTER && p.enemyHeroStartClass != CardClass.MAGE && p.enemyHeroStartClass != CardClass.PALADIN)
                    {
                        p.ownSecretsIDList.Add(CardIds.Collectible.Paladin.NobleSacrifice);
                    }

                    p.enemySecretList.RemoveAt(0);
                }
            }
            else
            {
                if (p.ownSecretsIDList.Count >= 1)
                {
                    p.ownSecretsIDList.RemoveAt(0);
                    var s = new SecretItem();
                    s.canBe_avenge = false;
                    s.canBe_sacredtrial = false;
                    s.canBe_counterspell = false;
                    s.canBe_cattrick = false;
                    s.canBe_duplicate = false;
                    s.canBe_explosive = false;
                    s.canBe_beartrap = false;
                    s.canBe_eyeforaneye = false;
                    s.canBe_freezing = false;
                    s.canBe_icebarrier = false;
                    s.canBe_iceblock = false;
                    s.canBe_mirrorentity = false;
                    s.canBe_missdirection = false;
                    s.canBe_darttrap = false;
                    s.canBe_noblesacrifice = false;
                    s.canBe_redemption = false;
                    s.canBe_repentance = false;
                    s.canBe_snaketrap = false;
                    s.canBe_snipe = false;
                    s.canBe_spellbender = false;
                    s.canBe_vaporize = false;

                    s.entityId = 1050;
                    s.canBe_explosive = true;

                    p.enemySecretList.Add(s);
                }
            }
        }
    }
}