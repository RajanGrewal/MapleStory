﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dango.MapleStory.Network
{
    /// <summary>
    /// 服务器发送的封包所包含的操作码
    /// </summary>
    public enum SendOperationCodes : short
    {
        // GENERAL---,
        Ping = 0x14,

        // LOGIN*,
        LoginStatus = 0x00,

        // 新连接,
        SendLink = 0xFF,

        // 许可协议,
        LicenseResult = 0x02,

        // 服务器状态,
        Serverstatus = 0x06,

        // 选择性别,
        ChooseGender = 0x04,

        // 性别选择返回,
        GenderSet = 0x05,

        //,
        //PIN_OPERATION = 0xFF,
        //PIN_ASSIGNED = 0xFF,
        //ALL_CHARLIST = 0xFF,
        // 服务器列表,
        Serverlist = 0x09,

        // 人物列表,
        Charlist = 0x0A,

        // 服务器IP,
        ServerIp = 0x0B,

        // 检查人物名反馈,
        CharNameResponse = 0x0C,

        // 增加新人物,
        AddNewCharEntry = 0x11,

        //,
        ChannelSelected = 0x18,
        RelogResponse = 0x16,

        // CHANNEL,
        // 频道更换,
        ChangeChannel = 0x13,

        // 道具栏信息,
        ModifyInventoryItem = 0x20,

        // 更新能力值,
        UpdateStats = 0x22,

        // 获得增益效果状态,
        GiveBuff = 0x23,

        // 取消增益效果状态,
        CancelBuff = 0x24,

        // 临时能力值开始,
        EnableTemporaryStats = 0x25,

        // 临时能力值结束,
        DisableTemporaryStats = 0x26,

        // 更新技能,
        UpdateSkills = 0x27,

        // 人气反馈,
        FameResponse = 0x29,

        // 人物具体信息,
        ShowStatusInfo = 0x2A,

        // 小纸条,
        ShowNotes = 0x2B,

        // 缩地石,
        TrockLocations = 0x2C,

        // 更新骑宠,
        UpdateMount = 0x32,

        // 任务完成效果,
        ShowQuestCompletion = 0x33,

        // 使用技能书,
        UseSkillBook = 0x35,

        // 报告玩家,
        ReportPlayerMsg = 0x39,

        // 家族BBS,
        BbsOperation = 0xFF,

        // 角色信息,
        CharInfo = 0x3A,

        // 开启组队,
        PartyOperation = 0x3B,

        // 好友列表,
        Buddylist = 0x3C,

        // 家族操作,
        GuildOperation = 0x3E,

        // 家族联盟,
        AllianceOperation = 0x3F,

        // 召唤门---,
        SpawnPortal = 0x40,

        // 服务器公告,
        Servermessage = 0x41,

        // 学院操作,
        FamilyAction = 0x45,

        // 情景喇叭,
        AvatarMega = 0x56,

        // 玩家NPC,
        PlayerNpc = 0x59,

        // 怪物卡,
        MonsterbookAdd = 0x5A,
        MonsterBookChangeCover = 0x5B,

        // 打开学院,
        OpenFamily = 0x63,
        FamilyMessage = 0x64,
        FamilyInvite = 0x65,
        FamilyMessage2 = 0x66,
        FamilySeniorMessage = 0x67,
        FamilyGainRep = 0x69,

        // 学院系统,
        LoadFamily = 0x6A,
        FamilyUseRequest = 0x6E,

        // 抵用卷,
        CharCash = 0x7D,

        // 技能宏,
        SkillMacro = 0x80,

        // 传送到地图,
        WarpToMap = 0x81,

        // 进入拍卖,
        MtsOpen = 0x82,

        // 进入商城,
        CsOpen = 0x83,

        // 返回错误信息,
        BlockMsg = 0x87,

        // 组队家族聊天,
        Multichat = 0x8A,

        // 悄悄话,
        Whisper = 0x8B,

        // 配偶聊天,
        SpouseChat = 0x8C,

        // BOSS血条,
        BossEnv = 0x8D,

        // 地图装备效果,
        ForcedMapEquip = 0x8F,

        // 地图效果,
        MapEffect = 0x91,

        // 管理员,
        GmPolice = 0x93,

        // ,
        Gm = 0x93,

        // GM活动命令,
        GmeventInstructions = 0x95,

        // 时钟,
        Clock = 0x96,

        // 船效果,
        BoatEffect = 0x98,

        // 召唤玩家,
        SpawnPlayer = 0xA2,

        // 移除玩家,
        RemovePlayerFromMap = 0xA3,

        // 聊天信息,
        Chattext = 0xA4,

        // 小黑板 ,
        Chalkboard = 0xA5,

        // 更新玩家,
        UpdateCharBox = 0xA6,

        // 卷轴效果,
        ShowScrollEffect = 0xA9,

        // 召唤宠物,
        SpawnPet = 0xAD,

        // 宠物移动,
        MovePet = 0xAF,
        PetChat = (short)(MovePet + 1),
        PetNamechange = (short)(MovePet + 2),
        PetCommand = (short)(MovePet + 4),

        // 召唤特殊到地图,
        SpawnSpecialMapobject = 0xB4,

        // 移除召唤从地图,
        RemoveSpecialMapobject = 0xB5,

        // 召唤兽移动,
        MoveSummon = 0xB6,

        // 召唤兽动作,
        SummonAttack = 0xB7,

        // 召唤兽伤害,
        DamageSummon = 0xB9,

        // 召唤兽技能,
        SummonSkill = 0xBA,

        // 移动玩家,
        MovePlayer = 0xBB,

        // 近距离攻击,
        CloseRangeAttack = 0xBC,
        RangedAttack = 0xBD,
        MagicAttack = 0xBE,

        // 技能效果,
        SkillEffect = 0xC0,

        // 取消技能效果,
        CancelSkillEffect = 0xC1,

        // 人物伤害,
        DamagePlayer = 0xC2,

        // 人物面部表情,
        FacialExpression = 0xC3,

        // 显示物品效果,
        ShowItemEffect = (short)(FacialExpression + 1),

        // 椅子效果,
        ShowChair = 0xC6,

        // 更新玩家外观,
        UpdateCharLook = 0xC7,

        // 玩家外观效果,
        ShowForeignEffect = 0xC8,

        // 获取异常状态,
        GiveForeignBuff = 0xC9,

        // 取消异常状态,
        CancelForeignBuff = 0xCA,

        // 更新组队HP显示,
        UpdatePartymemberHp = 0xCB,

        // 动画效果,
        AnimationEffect = 0xCE,

        // 取消椅子,
        CancelChair = 0xCF,

        // 增益物品效果显示,
        ShowItemGainInchat = 0xD0,

        // 武陵,
        DojoWarpUp = (short)(ShowItemGainInchat + 1),

        // 更新任务信息,
        UpdateQuestInfo = 0xD6,

        // 玩家提示,
        PlayerHint = 0xD9,
        TutorialDisableUi = 0xE3,
        TutorialLockUi = 0xE4,
        TutorialSummon = 0xE5,
        TutorialGuide = 0xE6,

        // 连击效果,
        ComboEffece = 0xE7,

        // 技能冷却,
        Cooldown = 0xEC,

        // 怪物召唤,
        SpawnMonster = 0xEE,

        // 杀死怪物,
        KillMonster = 0xEF,

        // 怪物召唤控制,
        SpawnMonsterControl = 0xF0,

        // 怪物移动,
        MoveMonster = 0xF1,

        // 移动怪物回应,
        MoveMonsterResponse = 0xF2,

        // 怪物伤害,
        DamageMonster = 0xF3,

        // 添加怪物状态,
        ApplyMonsterStatus = 0xF4,

        // 取消怪物状态,
        CancelMonsterStatus = 0xF5,

        // 能量,
        Energy = 0xFB,

        // ,
        AriantThing = 0xFB,

        // 显示怪物HP,
        ShowMonsterHp = 0xFC,

        // 磁铁效果,
        ShowMagnet = 0xFD,

        // 抓获怪物,
        CatchMonster = 0x102,

        // 召唤NPC,
        SpawnNpc = 0x104,

        // 移除NPC,
        RemoveNpc = 0x105,

        // 召唤NPC 请求控制权,
        SpawnNpcRequestController = 0x106,

        // NPC说话,
        NpcAction = 0x107,

        // 召唤雇佣商店,
        SpawnHiredMerchant = 0x10D,
        DestroyHiredMerchant = 0x10E,
        UpdateHiredMerchant = 0x10F,

        // 掉落物品在地图上,
        DropItemFromMapobject = 0x110,

        // 从地图上删除物品,
        RemoveItemFromMap = 0x111,

        // 召唤LOVE,
        SpawnLove = 0x113,

        // 取消LOVE,
        RemoveLove = 0x114,

        // 召唤烟雾,
        SpawnMist = 0x115,

        // 取消烟雾,
        RemoveMist = 0x116,

        // 召唤门,
        SpawnDoor = 0x11B,

        // 取消门,
        RemoveDoor = 0x11C,

        // 反应堆,
        ReactorHit = 0x11D,

        // 反应堆召唤,
        ReactorSpawn = 0x11E,

        // 重置反映堆,
        ReactorDestroy = 0x11F,

        // ---,
        AriantPqStart = 0x123,

        // 扎昆门,
        ZakumShrine = 0x129,
        MonsterCarnivalStart = 0xFF,
        MonsterCarnivalObtainedCp = 0xFF,
        MonsterCarnivalPartyCp = 0xFF,
        MonsterCarnivalSummon = 0xFF,
        MonsterCarnivalDied = 0xFF,

        // NPC交谈,
        NpcTalk = 0x145,

        // 打开NPC商店,
        OpenNpcShop = 0x146,

        // NPC商店确认,
        ConfirmShopTransaction = 0x147,

        // 打开仓库,
        OpenStorage = 0x14A,

        // 聊天招待,
        Messenger = 0x14E,

        // 玩家互动,
        PlayerInteraction = 0x14F,

        // 送货员,
        Duey = 0x15F,

        // 现金商店更新,
        CsUpdate = 0x161,

        // 现在商店操作,
        CsOperation = 0x162,

        // 键盘排序,
        Keymap = 0x16F,

        // 自动吃药HP,
        AutoHpPot = 0x170,
        AutoMpPot = 0x171,

        // 冒险岛TV,
        SendTv = 0x175,
        RemoveTv = 0x176,
        EnableTv = 0x177,

        // 拍卖操作,
        MtsOperation2 = 0x17B,
        MtsOperation = 0x17C,

        // 金锤子,
        ViciousHammer = 0x182,

        // 地图动画播放,
        CygnusIntroLock = 0xFF,

        // 地图动画结束,
        CygnusIntroDisableUi = 0xFF,

        // 人物动画创建,
        CygnusCharCreated = 0xFF
    }
}
