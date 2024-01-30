using HarmonyLib;
using SRML;
using SRML.SR;
using SRML.Console;
using SRML.Utils.Enum;
using SRML.SR.SaveSystem;
using SRML.SR.SaveSystem.Data;
using SRML.Config.Attributes;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using MonomiPark.SlimeRancher.DataModel;
using MonomiPark.SlimeRancher.Persist;
using System.Reflection.Emit;
using Console = SRML.Console.Console;
using Object = UnityEngine.Object;

namespace MoreCorralUpgrades
{
    public class Main : ModEntryPoint
    {
        internal static Assembly modAssembly = Assembly.GetExecutingAssembly();
        internal static string modName = $"{modAssembly.GetName().Name}";
        internal static string modDir = $"{Environment.CurrentDirectory}\\SRML\\Mods\\{modName}";

        public override void PreLoad()
        {
            HarmonyInstance.PatchAll();
            SaveRegistry.RegisterDataParticipant<Shrink>();
        }
        public override void Load()
        {
            var ts = Resources.FindObjectsOfTypeAll<Sprite>().Find(
                (x) => x.name == "iconPatchCorralNet",
                (x) => x.name == "iconCategoryPlort",
                (x) => x.name == "iconPatchGardenBase",
                (x) => x.name == "iconPatchSiloStorage",
                (x) => x.name == "iconShopPower01",
                (x) => x.name == "iconPatchCoopVitamizer",
                (x) => x.name == "iconPatchGardenSprinkler"
                );
            var t = ts[0].GetReadable();
            var t2 = LoadImage("iconOverlay.png", 512);
            t.texture.ModifyTexturePixels((j, k, l) => t2.Overlay(j, k, l));
            LandPlotUpgradeRegistry.RegisterPurchasableUpgrade<CorralUI>(new LandPlotUpgradeRegistry.UpgradeShopEntry()
            {
                cost = 700,
                icon = t,
                isUnlocked = (x) => x.HasUpgrade(LandPlot.Upgrade.AIR_NET),
                LandPlotName = "corral",
                landplotPediaId = PediaDirector.Id.CORRAL,
                isAvailable = (x) => !x.HasUpgrade(Ids.AIR_NET_BOOSTER),
                mainImg = t,
                upgrade = Ids.AIR_NET_BOOSTER
            });
            t = ts[1].GetReadable();
            t.texture.ModifyTexturePixels((j, k, l) => t2.Overlay(j, k, l));
            LandPlotUpgradeRegistry.RegisterPurchasableUpgrade<CorralUI>(new LandPlotUpgradeRegistry.UpgradeShopEntry()
            {
                cost = 1000,
                icon = t,
                isUnlocked = (x) => true,
                LandPlotName = "corral",
                landplotPediaId = PediaDirector.Id.CORRAL,
                isAvailable = (x) => !x.HasUpgrade(Ids.PLORT_PROTECTOR),
                mainImg = t,
                upgrade = Ids.PLORT_PROTECTOR
            });
            t = ts[2].GetReadable();
            t.texture.ModifyTexturePixels((j, k, l) => t2.Overlay(j, k, l));
            LandPlotUpgradeRegistry.RegisterPurchasableUpgrade<CorralUI>(new LandPlotUpgradeRegistry.UpgradeShopEntry()
            {
                cost = 400,
                icon = t,
                isUnlocked = (x) => true,
                LandPlotName = "corral",
                landplotPediaId = PediaDirector.Id.CORRAL,
                isAvailable = (x) => !x.HasUpgrade(Ids.MINI_GARDEN),
                mainImg = t,
                upgrade = Ids.MINI_GARDEN
            });
            t = ts[3].GetReadable();
            t.texture.ModifyTexturePixels((j, k, l) => t2.Overlay(j, k, l));
            LandPlotUpgradeRegistry.RegisterPurchasableUpgrade<CorralUI>(new LandPlotUpgradeRegistry.UpgradeShopEntry()
            {
                cost = 600,
                icon = t,
                isUnlocked = (x) => x.HasUpgrade(LandPlot.Upgrade.PLORT_COLLECTOR) || x.HasUpgrade(LandPlot.Upgrade.FEEDER),
                LandPlotName = "corral",
                landplotPediaId = PediaDirector.Id.CORRAL,
                isAvailable = (x) => !x.HasUpgrade(Ids.CAPACITY_BOOSTER),
                mainImg = t,
                upgrade = Ids.CAPACITY_BOOSTER
            });
            var garden = Resources.FindObjectsOfTypeAll<GardenUI>().First((x) => x.name == "GardenUI").clearCrop;
            LandPlotUpgradeRegistry.RegisterPurchasableUpgrade<CorralUI>(new LandPlotUpgradeRegistry.UpgradeShopEntry()
            {
                cost = garden.cost,
                icon = garden.icon,
                isUnlocked = (x) => x.HasAttached(),
                LandPlotName = "corral",
                landplotPediaId = PediaDirector.Id.CORRAL,
                isAvailable = (x) => true,
                mainImg = garden.img,
                upgrade = Ids.CLEAR_CROPS
            });
            t = ts[4].GetReadable();
            t.texture.ModifyTexturePixels((j, k, l) => t2.Overlay(j, k, l));
            LandPlotUpgradeRegistry.RegisterPurchasableUpgrade<CorralUI>(new LandPlotUpgradeRegistry.UpgradeShopEntry()
            {
                cost = 1250,
                icon = t,
                isUnlocked = (x) => x.HasUpgrade(Ids.PLORT_PROTECTOR),
                LandPlotName = "corral",
                landplotPediaId = PediaDirector.Id.CORRAL,
                isAvailable = (x) => !x.HasUpgrade(Ids.PROTECTOR_BATTERY),
                mainImg = t,
                upgrade = Ids.PROTECTOR_BATTERY
            });
            t = ts[5].GetReadable();
            t.texture.ModifyTexturePixels((j, k, l) => t2.Overlay(j, k, l));
            LandPlotUpgradeRegistry.RegisterPurchasableUpgrade<CorralUI>(new LandPlotUpgradeRegistry.UpgradeShopEntry()
            {
                cost = 1500,
                icon = t,
                isUnlocked = (x) => true,
                LandPlotName = "corral",
                landplotPediaId = PediaDirector.Id.CORRAL,
                isAvailable = (x) => !x.HasUpgrade(Ids.MINITURIZER),
                mainImg = t,
                upgrade = Ids.MINITURIZER
            });
            t = ts[6].GetReadable();
            t.texture.ModifyTexturePixels((j, k, l) => t2.Overlay(j, k, l));
            LandPlotUpgradeRegistry.RegisterPurchasableUpgrade<CorralUI>(new LandPlotUpgradeRegistry.UpgradeShopEntry()
            {
                cost = 750,
                icon = t,
                isUnlocked = (x) => true,
                LandPlotName = "corral",
                landplotPediaId = PediaDirector.Id.CORRAL,
                isAvailable = (x) => !x.HasUpgrade(LandPlot.Upgrade.SPRINKLER),
                mainImg = t,
                upgrade = LandPlot.Upgrade.SPRINKLER
            });
            LandPlotUpgradeRegistry.RegisterPlotUpgrader<CustomCorralUpgrader>(LandPlot.Id.CORRAL);
            if (SRModLoader.IsModPresent("dimensionwarpslime"))
                DWS.Setup();
        }
        public static void LogError(string message) => Debug.LogError($"[{modName}]: " + message);

        public static Texture2D LoadImage(string filename, int width) => LoadImage(filename, width, width);

        public static Texture2D LoadImage(string filename, int width, int height)
        {
            var a = modAssembly;
            var spriteData = a.GetManifestResourceStream(a.GetName().Name + "." + filename);
            if (spriteData == null)
            {
                LogError(filename + " does not exist in the assembly");
                return null;
            }
            var rawData = new byte[spriteData.Length];
            spriteData.Read(rawData, 0, rawData.Length);
            var tex = new Texture2D(width, height);
            tex.LoadImage(rawData);
            tex.filterMode = FilterMode.Bilinear;
            return tex;
        }

        class CustomCorralUpgrader : PlotUpgrader
        {
            List<AirNet> modifiedNets = new List<AirNet>();
            List<SiloStorage> modifiedStorages = new List<SiloStorage>();
            List<SiloSlotUI> modifiedSlots = new List<SiloSlotUI>();
            LandPlot plot;

            void Awake()
            {
                plot = GetComponent<LandPlot>();

                var ls = Resources.FindObjectsOfTypeAll<LandPlot>().First((x) => x.name == "patchGarden");
                var soilPrefab = ls.transform.Find("Soil");
                var depositPrefab = ls.transform.Find("techDepositor");
                var garden = new GameObject("Garden").transform;
                garden.SetParent(transform,false);
                garden.gameObject.SetActive(false);
                var newSoil = Instantiate(soilPrefab, garden);
                newSoil.name = newSoil.name.Replace("(Clone)", "");
                newSoil.localPosition = soilPrefab.localPosition;
                newSoil.localScale = soilPrefab.localScale;
                newSoil.localRotation = soilPrefab.localRotation;
                var newDeposit = Instantiate(depositPrefab, garden);
                newDeposit.name = newDeposit.name.Replace("(Clone)", "");
                newDeposit.localPosition = depositPrefab.localPosition;
                newDeposit.localScale = depositPrefab.localScale;
                newDeposit.localRotation = depositPrefab.localRotation;
                newDeposit.GetComponentInChildren<GardenCatcher>().activator = plot;
                newDeposit.GetComponentInChildren<GardenCountdownUI>().plot = plot;


                var area = transform.Find("PlortCollector/CollectionArea").gameObject.GetComponent<BoxCollider>();
                var protectParent = new GameObject("PlortProtector").transform;
                protectParent.gameObject.SetActive(false);
                protectParent.SetParent(transform,false);
                var nArea = new GameObject("Area", typeof(BoxCollider), typeof(PlortProtector)).GetComponent<BoxCollider>();
                nArea.transform.SetParent(protectParent);
                area.CopyAllTo(nArea);
                nArea.isTrigger = true;
                nArea.transform.position = area.transform.position;
                nArea.transform.rotation = area.transform.rotation;
                nArea.transform.localScale = area.transform.localScale;

                var DroneDefinition = GameContext.Instance.LookupDirector.GetGadgetDefinition(Gadget.Id.DRONE);
                var WaterMeterPrefab = DroneDefinition.prefab.transform.Find("drone_station/techActivator/waterMeter").gameObject;
                var WaterMeter = Instantiate(WaterMeterPrefab, protectParent, false);
                WaterMeter.name = $"waterMeter";
                var Collider = WaterMeter.AddComponent<CapsuleCollider>();
                Collider.height = 1;
                Collider.radius = 0.25f;
                WaterMeter.transform.localScale = new Vector3(1, 2, 1);
                WaterMeter.transform.localPosition = new Vector3(-5.3f, -0.6f, 5.3f);
                WaterMeter.transform.localRotation *= Quaternion.Euler(0, -90, 0);
                var protect = nArea.GetComponent<PlortProtector>();
                protect.meter = WaterMeter.transform.Find("water");


                var miniturizer = new GameObject("Miniturizer", typeof(BoxCollider), typeof(Miniturizer)).transform;
                miniturizer.gameObject.SetActive(false);
                miniturizer.SetParent(transform, false);
                nArea = miniturizer.GetComponent<BoxCollider>();
                area.CopyAllTo(nArea);
                nArea.isTrigger = true;
                nArea.transform.position = area.transform.position;
                nArea.transform.rotation = area.transform.rotation;
                nArea.transform.localScale = area.transform.localScale;


                
                var sprinkler = new GameObject("Sprinkler").transform;
                sprinkler.gameObject.SetActive(false);
                sprinkler.SetParent(transform, false);
                nArea = new GameObject("Area", typeof(BoxCollider), typeof(SlimeSprinkler)).GetComponent<BoxCollider>();
                nArea.transform.SetParent(sprinkler);
                area.CopyAllTo(nArea);
                nArea.isTrigger = true;
                nArea.transform.position = area.transform.position;
                nArea.transform.rotation = area.transform.rotation;
                nArea.transform.localScale = area.transform.localScale;
                Instantiate(ls.transform.Find("Sprinkler").gameObject, sprinkler, false).SetActive(true);
            }
            public override void Apply(LandPlot.Upgrade upgrade)
            {
                if (upgrade == Ids.AIR_NET_BOOSTER || plot.HasUpgrade(Ids.AIR_NET_BOOSTER))
                    foreach (var n in GetComponentsInChildren<AirNet>(true))
                    {
                        if (modifiedNets.Contains(n))
                            continue;
                        n.hitForceToDestroy /= 2;
                        n.dmgPerImpulse /= 2;
                        modifiedNets.Add(n);
                    }

                if (upgrade == Ids.PLORT_PROTECTOR)
                    transform.Find("PlortProtector").gameObject.SetActive(true);

                if (upgrade == Ids.MINI_GARDEN)
                    transform.Find("Garden").gameObject.SetActive(true);

                if (upgrade == Ids.CAPACITY_BOOSTER || plot.HasUpgrade(Ids.CAPACITY_BOOSTER))
                {
                    foreach (var s in GetComponentsInChildren<SiloStorage>(true))
                    {
                        if (modifiedStorages.Contains(s))
                            continue;
                        s.maxAmmo *= 3;
                        modifiedStorages.Add(s);
                    }
                    foreach (var s in GetComponentsInChildren<SiloSlotUI>(true))
                    {
                        if (modifiedSlots.Contains(s))
                            continue;
                        s.bar.maxValue *= 3;
                        modifiedSlots.Add(s);
                    }
                }

                if (upgrade == Ids.CLEAR_CROPS)
                {
                    plot.DestroyAttached();
                    plot.model.upgrades.Remove(Ids.CLEAR_CROPS);
                }

                if (upgrade == Ids.PROTECTOR_BATTERY)
                {
                    transform.Find("PlortProtector/Area").GetComponent<PlortProtector>().batteryCapacity *= 3;
                    var m = transform.Find("PlortProtector/waterMeter");
                    m.localScale += new Vector3(0, m.localScale.y * 0.5f, 0);
                    m.localPosition += new Vector3(0, m.localPosition.y * 0.5f, 0);
                }

                if (upgrade == Ids.MINITURIZER)
                    transform.Find("Miniturizer").gameObject.SetActive(true);
                
                if ((upgrade == LandPlot.Upgrade.WALLS || upgrade == Ids.MINITURIZER) && (upgrade == LandPlot.Upgrade.WALLS || plot.HasUpgrade(LandPlot.Upgrade.WALLS)))
                {
                    if (upgrade == Ids.MINITURIZER || plot.HasUpgrade(Ids.MINITURIZER))
                    {
                        var area = transform.Find("Miniturizer").GetComponent<BoxCollider>();
                        area.size += new Vector3(0, area.size.y, 0);
                        area.center -= new Vector3(0, area.center.y, 0);
                    }
                    if (upgrade == Ids.PLORT_PROTECTOR || plot.HasUpgrade(Ids.PLORT_PROTECTOR))
                    {
                        var area = transform.Find("PlortProtector/Area").GetComponent<BoxCollider>();
                        area.size += new Vector3(0, area.size.y, 0);
                        area.center -= new Vector3(0, area.center.y, 0);
                    }
                }

                if (upgrade == LandPlot.Upgrade.SPRINKLER)
                    transform.Find("Sprinkler").gameObject.SetActive(true);
            }
        }
    }

    class PlortProtector : SRBehaviour, LiquidConsumer
    {
        public static List<PlortProtector> protectors = new List<PlortProtector>();
        public List<Identifiable> protect = new List<Identifiable>();
        LandPlot _p;
        LandPlot plot
        {
            get
            {
                if (!_p)
                    _p = GetComponentInParent<LandPlot>();
                return _p;
            }
        }
        internal double batteryTime
        {
            get => plot.model == null ? 0 : plot.model.attachedDeathTime;
            set
            {
                if (plot.model != null)
                    plot.model.attachedDeathTime = value;
            }
        }
        public Transform meter;
        public float batteryCapacity = 48;
        public float remainingCharge => Mathf.Clamp01((float)(SceneContext.Instance.TimeDirector.HoursUntil(batteryTime) / batteryCapacity));
        float waterMeter { set => meter.localScale = new Vector3(1, value, 1); }
        public bool isActive => remainingCharge > 0;
        void Awake() => protectors.Add(this);
        void OnTriggerEnter(Collider other)
        {
            protect.RemoveAll((x) => !x);
            var i = other.GetComponentInParent<Identifiable>();
            if (i && Identifiable.IsPlort(i.id))
                protect.AddUnique(i);
        }

        void OnTriggerExit(Collider other)
        {
            protect.RemoveAll((x) => !x);
            var i = other.GetComponentInParent<Identifiable>();
            if (i)
                protect.Remove(i);
        }
        void OnDestroy() => protectors.Remove(this);

        public void AddLiquid(Identifiable.Id id, float amount) => batteryTime = SceneContext.Instance.TimeDirector.HoursFromNow(Mathf.Clamp01(remainingCharge + 4 / batteryCapacity * amount) * batteryCapacity);

        void Update() => waterMeter = remainingCharge;
    }

    class Miniturizer : SRBehaviour
    {
        public static List<Miniturizer> holders = new List<Miniturizer>();
        public List<Identifiable> affectedObj = new List<Identifiable>();
        void Awake() => holders.Add(this);
        void OnTriggerEnter(Collider other)
        {
            affectedObj.RemoveAll((x) => !x);
            if (other.isTrigger)
                return;
            var i = other.GetComponentInParent<Identifiable>();
            if (i)
            {
                if ((Identifiable.IsPlort(i.id) || Identifiable.IsSlime(i.id) || Identifiable.IsAnimal(i.id) || Identifiable.IsToy(i.id) || Identifiable.IsFood(i.id)) && affectedObj.AddUnique(i)) {
                    var s = i.GetComponent<Shrink>();
                    if (s)
                        s.StopDestroy();
                    else
                        s = i.gameObject.AddComponent<Shrink>();
                }
            }
        }

        void OnTriggerExit(Collider other)
        {
            affectedObj.RemoveAll((x) => !x);
            if (other.isTrigger)
                return;
            var i = other.GetComponentInParent<Identifiable>();
            if (i) {
                affectedObj.Remove(i);
                if (!IsHeld(i))
                    i.GetComponent<Shrink>()?.Destroy();
            }

        }
        void OnDestroy()
        {
            holders.Remove(this);
            foreach (var i in affectedObj)
                if (i && !IsHeld(i))
                    i.GetComponent<Shrink>()?.Destroy();
        }

        public static bool IsHeld(Identifiable identifiable)
        {
            holders.RemoveAll((x) => !x);
            return holders.Exists((x) => x.isActiveAndEnabled && x.affectedObj.Contains(identifiable));
        }
    }

    class SlimeSprinkler : SRBehaviour
    {
        BoxCollider area;
        float time = 5;
        List<Identifiable> objs = new List<Identifiable>();
        void Awake() => area = GetComponent<BoxCollider>();
        void Update()
        {
            time += Time.deltaTime;
            if (time > 5)
            {
                time %= 5;
                objs.RemoveAll((x) => !x);
                foreach (var o in objs)
                    foreach (var l in o.GetComponentsInChildren<LiquidConsumer>())
                        l.AddLiquid(Identifiable.Id.WATER_LIQUID, 1);
            }
        }
        void OnTriggerEnter(Collider other)
        {
            objs.RemoveAll((x) => !x);
            if (other.isTrigger)
                return;
            var i = other.GetComponentInParent<Identifiable>();
            if (i && Identifiable.IsSlime(i.id)) objs.AddUnique(i);
        }

        void OnTriggerExit(Collider other)
        {
            objs.RemoveAll((x) => !x);
            if (other.isTrigger)
                return;
            var i = other.GetComponentInParent<Identifiable>();
            if (i)
                objs.Remove(i);
        }
    }

    class Shrink : SRBehaviour, ExtendedData.Participant
    {
        Vector3 start;
        float progress = 0;
        float progress2 = 0;
        bool Destroying = false;
        Identifiable id;
        static Dictionary<Identifiable.Id, Vector3> originalSizes = new Dictionary<Identifiable.Id, Vector3>();
        [NonSerialized]
        public bool produced = false;
        [NonSerialized]
        public float producedStart = 0.01f;
        [NonSerialized]
        public float producedAnimation = 1;
        void Awake()
        {
            id = GetComponent<Identifiable>();
            if (!originalSizes.TryGetValue(id.id, out start))
            {
                start = GameContext.Instance.LookupDirector.GetPrefab(id.id).transform.localScale;
                originalSizes[id.id] = start;
            }
        }
        void Start()
        {
            if (!Miniturizer.IsHeld(id))
                Destroy();
        }
        public void Destroy() => Destroying = true;
        public void StopDestroy() => Destroying = false;

        void Update()
        {
            if (Destroying)
            {
                progress -= Time.deltaTime / Config.MiniturizerAnimationTime;
                if (progress <= 0)
                {
                    progress = 0;
                    produced = false;
                    UpdateSize();
                    DestroyImmediate(this);
                    return;
                }
            }
            else if (progress < 1)
            {
                progress += Time.deltaTime / Config.MiniturizerAnimationTime;
                if (progress > 1)
                    progress = 1;
            }
            if (produced)
            {
                progress2 += Time.deltaTime / producedAnimation;
                if (progress2 >= 1)
                    produced = false;
            }
            if (transform.localScale != size)
                UpdateSize();
        }

        Vector3 size => start * (1 - progress * (1 - Config.MiniturizerSize)) * (produced ? producedStart + (1-producedStart) * progress2 : 1);

        void UpdateSize() => transform.localScale = size;

        public void ReadData(CompoundDataPiece data)
        {
            if (data.HasPiece("progress"))
                progress = data.GetValue<float>("progress");
            if (data.HasPiece("destroying"))
                Destroying = data.GetValue<bool>("destroying");
            UpdateSize();
        }

        public void WriteData(CompoundDataPiece data)
        {
            data.SetValue("progress", progress);
            data.SetValue("destroying", Destroying);
        }
    }

    [HarmonyPatch(typeof(ResourceBundle), "LoadFromText")]
    class Patch_LoadResources
    {
        static void Postfix(string path, Dictionary<string, string> __result)
        {
            if (path == "pedia")
            {
                var lang = GameContext.Instance.MessageDirector.GetCultureLang();
                if (lang == MessageDirector.Lang.RU)
                {
                    __result.Add(Ids.AIR_NET_BOOSTER, "Улучшение воздушной сети", "Увеличивает прочность воздушной сети так, чтобы она смогла выдержать больше ударов");
                    __result.Add(Ids.PLORT_PROTECTOR, "Защитник плортов", "Уберегает плорты от съедения слаймами внутри загона при заряженной батарее");
                    __result.Add(Ids.PROTECTOR_BATTERY, "Улучшение батареи", "Утраивает максимальный заряд батареи защитника плортов");
                    __result.Add(Ids.MINI_GARDEN, "Внутренний сад", "Добавляет сад в загон");
                    __result.Add(Ids.CAPACITY_BOOSTER, "Улучшение хранилища", "Утраивает объем всех хранилищ загона");
                    __result.Add(Ids.MINITURIZER, "Уменьшитель", "Уменьшает размер всех слаймов, игрушек и еды внутри загона в 2 раза");
                    __result.Add(LandPlot.Upgrade.SPRINKLER, "Опрыскиватель слаймов", "Регулярно обрызгивает слаймов в загоне водой");
                    __result.Add(Ids.CLEAR_CROPS, "Очистить грядку", "Убирает растения из внутреннего сада");
                }
                else
                {
                    __result.Add(Ids.AIR_NET_BOOSTER, "Air Net Upgrade", "Increase strength of the air net so that it can take more hits");
                    __result.Add(Ids.PLORT_PROTECTOR, "Plort Protector", "Prevents slimes within the corral eating plorts while it's battery is charged");
                    __result.Add(Ids.PROTECTOR_BATTERY, "Battery Upgrade", "Triples the capacity of the Plort Protector's battery");
                    __result.Add(Ids.MINI_GARDEN, "Internal Garden", "Adds a garden to the corral");
                    __result.Add(Ids.CAPACITY_BOOSTER, "Increase Storage Capacity", "Triples the capacity of all storages on the corral");
                    __result.Add(Ids.MINITURIZER, "Miniturizer", "Reduces the size of all the slimes, toys and fruit that enter the corral");
                    __result.Add(LandPlot.Upgrade.SPRINKLER, "Slime Sprinkler", "Regularly sprinkles the slimes within the corral with water");
                    __result.Add(Ids.CLEAR_CROPS, "Clear Crops", "Removes the crop from the Internal Garden");
                }
            }
        }
    }

    [HarmonyPatch(typeof(SlimeEat), "EatAndTransform")]
    class Patch_SlimeEat
    {
        static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            var code = instructions.ToList();
            var ind = code.FindIndex((x) => x.opcode == OpCodes.Call && x.operand is MethodInfo && (x.operand as MethodInfo).DeclaringType == typeof(SRBehaviour) && (x.operand as MethodInfo).Name == "InstantiateActor") + 1;
            code.Insert(ind++, new CodeInstruction(OpCodes.Ldarg_0));
            code.Insert(ind++, new CodeInstruction(OpCodes.Call, AccessTools.Method(typeof(Patch_SlimeEat), nameof(Modify))));
            return code;
        }
        static GameObject Modify(GameObject newSlime, SlimeEat original)
        {
            var t1 = original.GetComponent<Shrink>();
            if (!t1)
                return newSlime;
            var t2 = newSlime.GetComponent<Shrink>();
            if (!t2)
                t2 = newSlime.AddComponent<Shrink>();
            t2.produced = true;
            t2.producedStart = original.transform.localScale.x;
            t2.producedAnimation = 0.5f;
            var data = new CompoundDataPiece("");
            t1.WriteData(data);
            t2.ReadData(data);
            return newSlime;
        }
    }

    [HarmonyPatch(typeof(SlimeEat), "Produce")]
    class Patch_SlimeEatProduce
    {
        static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            var code = instructions.ToList();
            var ind = code.FindIndex((x) => x.opcode == OpCodes.Call && x.operand is MethodInfo && (x.operand as MethodInfo).DeclaringType == typeof(SRBehaviour) && (x.operand as MethodInfo).Name == "InstantiateActor") + 1;
            code.Insert(ind++, new CodeInstruction(OpCodes.Ldarg_0));
            code.Insert(ind++, new CodeInstruction(OpCodes.Call, AccessTools.Method(typeof(Patch_SlimeEatProduce), nameof(Modify))));
            return code;
        }
        static GameObject Modify(GameObject newSlime, SlimeEat original)
        {
            var t1 = original.GetComponent<Shrink>();
            if (!t1)
                return newSlime;
            var t2 = newSlime.GetComponent<Shrink>();
            if (!t2)
                t2 = newSlime.AddComponent<Shrink>();
            t2.produced = true;
            var data = new CompoundDataPiece("");
            t1.WriteData(data);
            t2.ReadData(data);
            return newSlime;
        }
    }

    [HarmonyPatch(typeof(Identifiable), "IsEdible", new Type[0] )]
    class Patch_IsEdible
    {
        static void Postfix(Identifiable __instance, ref bool __result)
        {
            PlortProtector.protectors.RemoveAll((x) => !x);
            if (__result && PlortProtector.protectors.Exists((x) => x.isActiveAndEnabled && x.isActive && x.protect.Contains(__instance)))
                __result = false;
        }
    }

    [HarmonyPatch(typeof(MonomiPark.SlimeRancher.SavedGame), "Pull", typeof(GameModel),typeof(RanchV07))]
    class Patch_PullRanchData
    {
        static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            var code = instructions.ToList();
            var ind = code.FindIndex((x) => x.opcode == OpCodes.Callvirt && x.operand is MethodInfo && (x.operand as MethodInfo).DeclaringType == typeof(LandPlotModel) && (x.operand as MethodInfo).Name == "Pull") + 1;
            var ind2 = code.FindLastIndex(code.FindLastIndex(ind, (x) => x.opcode == OpCodes.Ldloca_S) - 1, (x) => x.opcode == OpCodes.Ldloca_S);
            code.Insert(ind, new CodeInstruction(code[ind++]));
            code.Insert(ind++, new CodeInstruction(code[ind2]));
            code.Insert(ind++, new CodeInstruction(code[ind2 + 1]));
            code.Insert(ind++, new CodeInstruction(OpCodes.Call, AccessTools.Method(typeof(Patch_PullRanchData), nameof(SaveStuff))));
            return code;
        }
        static void SaveStuff(LandPlotV08 raw, LandPlotModel model)
        {
            raw.attachedDeathTime = model.attachedDeathTime;
        }
    }

    [HarmonyPatch(typeof(MonomiPark.SlimeRancher.SavedGame), "LandPlotToGameObject")]
    class Patch_PushLandPlotData
    {
        static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            var code = instructions.ToList();
            var ind = code.FindIndex((x) => x.opcode == OpCodes.Callvirt && x.operand is MethodInfo && (x.operand as MethodInfo).DeclaringType == typeof(LandPlotModel) && (x.operand as MethodInfo).Name == "Push") + 1;
            code.Insert(ind++, new CodeInstruction(OpCodes.Ldarg_1));
            code.Insert(ind++, new CodeInstruction(OpCodes.Ldloc_0));
            code.Insert(ind++, new CodeInstruction(OpCodes.Call, AccessTools.Method(typeof(Patch_PushLandPlotData), nameof(LoadStuff))));
            return code;
        }
        static void LoadStuff(LandPlotV08 raw, LandPlotModel model)
        {
            model.attachedDeathTime = raw.attachedDeathTime;
        }
    }

    [HarmonyPatch(typeof(LandPlot), "SetModel")]
    class Patch_ApplyUpgrades
    {
        static void Prefix(LandPlotModel model)
        {
            model.upgrades.Remove(Ids.CLEAR_CROPS);
        }
    }

    [EnumHolder]
    static class Ids
    {
        public static LandPlot.Upgrade AIR_NET_BOOSTER;
        public static LandPlot.Upgrade PLORT_PROTECTOR;
        public static LandPlot.Upgrade PROTECTOR_BATTERY;
        public static LandPlot.Upgrade MINI_GARDEN;
        public static LandPlot.Upgrade CAPACITY_BOOSTER;
        public static LandPlot.Upgrade MINITURIZER;
        public static LandPlot.Upgrade CLEAR_CROPS;
    }

    [ConfigFile("settings")]
    public static class Config
    {
        public static float MiniturizerSize = 0.5f;
        public static float MiniturizerAnimationTime = 1;
    }

    static class ExtentionMethods
    {
        public static Sprite GetReadable(this Sprite source)
        {
            return Sprite.Create(source.texture.GetReadable(), source.rect, source.pivot, source.pixelsPerUnit);
        }

        public static Texture2D GetReadable(this Texture2D source)
        {
            RenderTexture temp = RenderTexture.GetTemporary(source.width, source.height, 0, RenderTextureFormat.Default, RenderTextureReadWrite.Linear);
            Graphics.Blit(source, temp);
            RenderTexture prev = RenderTexture.active;
            RenderTexture.active = temp;
            Texture2D texture = new Texture2D(source.width, source.height);
            texture.ReadPixels(new Rect(0, 0, temp.width, temp.height), 0, 0);
            texture.Apply();
            RenderTexture.active = prev;
            RenderTexture.ReleaseTemporary(temp);
            return texture;
        }

        public static Sprite CreateSprite(this Texture2D texture) => Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f), 1);

        public static List<Y> GetAll<X, Y>(this IEnumerable<X> os, Func<X, IEnumerable<Y>> collector, bool ignoreDuplicates = true)
        {
            var l = new List<Y>();
            foreach (var o in os)
            {
                var c = collector(o);
                if (c != null)
                {
                    if (ignoreDuplicates)
                        l.AddRangeUnique(c);
                    else
                        l.AddRange(c);
                }
            }
            return l;
        }

        public static void AddRangeUnique<X>(this List<X> c, IEnumerable<X> collection)
        {
            foreach (var i in collection)
                c.AddUnique(i);
        }

        public static bool AddUnique<X>(this List<X> c, X value)
        {
            if (!c.Contains(value))
            {
                c.Add(value);
                return true;
            }
            return false;
        }

        public static T[] Find<T>(this IEnumerable<T> c, params Predicate<T>[] preds)
        {
            var f = new T[preds.Length];
            if (preds.Length == 0)
                return f;
            foreach (var i in c)
            {
                var k = 0;
                for (int j = 0; j < preds.Length; j++)
                {
                    if (f[j] != null)
                    {
                        k++;
                        continue;
                    }
                    if (preds[j](i))
                    {
                        k++;
                        f[j] = i;
                    }
                }
                if (k == preds.Length)
                    continue;
            }
            return f;
        }

        public static void ModifyTexturePixels(this Texture2D texture, Func<Color, Color> colorChange)
        {
            for (int m = 0; m < texture.mipmapCount; m++)
            {
                var p = texture.GetPixels(m);
                for (int x = 0; x < p.Length; x++)
                    p[x] = colorChange(p[x]);
                texture.SetPixels(p, m);
            }
            texture.Apply(true);
        }

        public static void ModifyTexturePixels(this Texture2D texture, Func<Color, float, float, Color> colorChange)
        {
            //for (int m = 0; m < texture.mipmapCount; m++)
            //{
                //var mipWidth = max(1, width >> miplevel);
                var p = texture.GetPixels();
                for (int x = 0; x < p.Length; x++)
                    p[x] = colorChange(p[x], (x % texture.width + 1) / (float)texture.width, (x / texture.width + 1) / (float)texture.height);
                texture.SetPixels(p);
            //}
            texture.Apply(true);
        }

        public static Color Overlay(this Texture2D t, Color c, float u, float v)
        {
            var c2 = t.GetPixelBilinear(u, v);
            return new Color(c.r * (1 - c2.a) + c2.r * c2.a, c.g * (1 - c2.a) + c2.g * c2.a, c.b * (1 - c2.a) + c2.b * c2.a, Mathf.Max(c.a, c2.a));
        }

        public static void Add(this Dictionary<string,string> col, LandPlot.Upgrade id, string name, string desc, LandPlot.Id plot = LandPlot.Id.CORRAL)
        {
            col[$"m.upgrade.name.{plot.ToString().ToLowerInvariant()}.{id.ToString().ToLowerInvariant()}"] = name;
            col[$"m.upgrade.desc.{plot.ToString().ToLowerInvariant()}.{id.ToString().ToLowerInvariant()}"] = desc;
        }
    }

    class DWS
    {
        public static void Setup()
        {
            DimensionWarpSlime.EnergyRegistry.RegisterReceiver<PlortProtector>(
                (x) => (1 - x.remainingCharge) * x.batteryCapacity,
                (x,y) => x.batteryTime = SceneContext.Instance.TimeDirector.HoursFromNow(x.remainingCharge * x.batteryCapacity + y)
                );
        }
    }
}