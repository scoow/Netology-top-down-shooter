using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Threading;
using System.Threading.Tasks;
using TDShooter.Configs;
using UnityEngine;

namespace TDShooter
{
    public class ArmorAbility : Ability
    {
        [SerializeField] Material _armorMeshRenderer;
        [SerializeField] GameObject _armor;


        public void ShowAbility(LootData_SO currentLootData_SO) //показываем щит
        {
            //StartCoroutine(ArmorRender(currentLootData_SO));
            _armor.SetActive(true);
            ArmorRenderAsunc(currentLootData_SO);
            //_armor.SetActive(false);
        }

        //IEnumerator ArmorRender(LootData_SO currentLootData_SO)
        //{
        //    var timer = currentLootData_SO.EffectTime;
        //    for (float f = 1f; f >= 0; f -= 0.05f)
        //    {
        //        //_armorMeshRenderer.SetColor("_Color", new Color(255,255,255,255*f));
        //        _armorMeshRenderer.SetFloat("_Metallic", f);
        //        _armorMeshRenderer.SetFloat("_Glossiness", f);
        //        yield return new WaitForSeconds(0.05f);
        //    }
        //    while (timer > 0)
        //    {
        //        yield return new WaitForSeconds(1f);
        //        timer -= 1;
        //        if (timer == 0)
        //        {
        //            for (float f = 0f; f <= 1; f += 0.05f)
        //            {
        //                //_armorMeshRenderer.SetColor("_Color", new Color(255,255,255,255*f));
        //                _armorMeshRenderer.SetFloat("_Metallic", f);
        //                _armorMeshRenderer.SetFloat("_Glossiness", f);
        //                yield return new WaitForSeconds(0.05f);
        //            }
        //            _armor.SetActive(false); //_armorMeshRenderer.SetColor("_Color", new Color(255, 255, 255, 0f));
        //        } 
        //    }
        //}
        private async void ArmorRenderAsunc(LootData_SO currentLootData_SO)
        {
            var timer = currentLootData_SO.EffectTime;
            float f;
            for (f = 1f; f >= 0; f -= 0.1f)
            {
                //_armorMeshRenderer.SetColor("_Color", new Color(255,255,255,255*f));
                _armorMeshRenderer.SetFloat("_Metallic", f);
                await UniTask.Delay(100);                
            }
            if (f <= 0)
            {
                await UniTask.Delay(Convert.ToInt32( 1000*timer));
                _armor.SetActive(false);
                /*while (timer > 0)
                {
                    await UniTask.Delay(1000);
                    timer -= 1;
                    _armorMeshRenderer.SetFloat("_Metallic", f);
                    if (timer == 0) _armor.SetActive(false); //_armorMeshRenderer.SetColor("_Color", new Color(255, 255, 255, 0f));
                }*/
            }
        }
    }
}