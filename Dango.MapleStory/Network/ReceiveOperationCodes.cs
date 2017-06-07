namespace Dango.MapleStory.Network
{
    /// <summary>
    /// 从客户端接收的封包所包含的操作码
    /// </summary>
    public enum ReceiveOperationCodes : short
    {
        /// <summary>
        /// TODO
        /// </summary>
        Pong = 0x13,

        /// <summary>
        /// 客户端错误
        /// </summary>
        ClientError = 0xFF,

        /// <summary>
        /// 异常数据
        /// </summary>
        StrangeData = 0x15,

        /// <summary>
        /// 登陆密码
        /// </summary>
        LoginPassword = 0x01,

        /// <summary>
        /// TODO:再次请求服务器列表
        /// </summary>
        ServerlistRerequest = 0xFF,

        /// <summary>
        /// 请求服务器列表
        /// </summary>
        ServerlistRequest = 0x02,

        /// <summary>
        /// 许可协议回复
        /// </summary>
        LicenseRequest = 0x03,

        /// <summary>
        /// 选择性别
        /// </summary>
        SetGender = 0x04,

        /// <summary>
        /// 请求服务器状态
        /// </summary>
        ServerstatusRequest = 0x05,

        /// <summary>
        /// 请求人物列表
        /// </summary>
        CharlistRequest = 0x09,
        AfterLogin = 0xFF,
        RegisterPin = 0xFF,
        ToWorldlist = 0xFF,
        ViewAllCharRequest = 0xFF,
        ViewAllCharConnect = 0xFF,
        ViewAllChar = 0xFF,

        /// <summary>
        /// 选择角色
        /// </summary>
        CharSelect = 0x0A,

        /// <summary>
        /// 检查人物名字
        /// </summary>
        CheckCharName = 0x0C,

        /// <summary>
        /// 创建人物
        /// </summary>
        CreateChar = 0x11,

        /// <summary>
        /// 错误日志
        /// </summary>
        ErrorLog = 0x14,

        /// <summary>
        /// TODO: 日志
        /// </summary>
        Relog = 0x19,

        /// <summary>
        /// TODO: Channel 登陆请求
        /// </summary>
        PlayerLoggedin = 0x0B,

        /// <summary>
        /// 更换地图
        /// </summary>
        ChangeMap = 0x21,

        /// <summary>
        /// 更换频道
        /// </summary>
        ChangeChannel = 0x22,

        /// <summary>
        /// 进入商城
        /// </summary>
        EnterCashShop = 0x23,

        /// <summary>
        /// 人物移动
        /// </summary>
        MovePlayer = 0x24,

        /// <summary>
        /// 取消椅子
        /// </summary>
        CancelChair = 0x25,

        /// <summary>
        /// 使用椅子
        /// </summary>
        UseChair = 0x26,

        /// <summary>
        /// 近距离攻击
        /// </summary>
        CloseRangeAttack = 0x28,

        /// <summary>
        /// 远距离攻击
        /// </summary>
        RangedAttack = 0x29,

        /// <summary>
        /// 魔法攻击
        /// </summary>
        MagicAttack = 0x2A,

        /// <summary>
        /// 能量攻击
        /// </summary>
        PassiveEnergy = 0x2B,

        /// <summary>
        /// TODO: 吸能攻击？
        /// </summary>
        EnergyChargeAttack = 0xFF,

        /// <summary>
        /// 受到伤害
        /// </summary>
        TakeDamage = 0x2C,

        /// <summary>
        /// 普通聊天
        /// </summary>
        GeneralChat = 0x2D,

        /// <summary>
        /// 关闭黑板
        /// </summary>
        CloseChalkboard = 0x2E,

        /// <summary>
        /// 人物面部表情
        /// </summary>
        FaceExpression = 0x2F,

        /// <summary>
        /// 使用物品效果
        /// </summary>
        UseItemeffect = FaceExpression + 1,

        /// <summary>
        /// TODO: 复活物品？
        /// </summary>
        ReviveItem = 0x31,

        /// <summary>
        /// 怪物卡片
        /// </summary>
        MonsterBookCover = 0x35,

        /// <summary>
        /// NPC交谈
        /// </summary>
        NpcTalk = 0x36,

        /// <summary>
        /// NPC详细交谈
        /// </summary>
        NpcTalkMore = 0x38,

        /// <summary>
        /// NPC商店
        /// </summary>
        NpcShop = 0x3A,

        /// <summary>
        /// 仓库
        /// </summary>
        Storage = 0x3B,

        /// <summary>
        /// 雇佣商店
        /// </summary>
        HiredMerchantRequest = 0x3C,

        /// <summary>
        /// 送货员
        /// </summary>
        DueyAction = 0x3E,

        /// <summary>
        /// 物品整理
        /// </summary>
        ItemSort = 0x42,

        /// <summary>
        /// 物品排序
        /// </summary>
        ItemSort2 = 0x43,

        /// <summary>
        /// 物品移动
        /// </summary>
        ItemMove = 0x44,

        /// <summary>
        /// 使用物品
        /// </summary>
        UseItem = 0x45,

        /// <summary>
        /// 取消物品结果
        /// </summary>
        CancelItemEffect = 0x46,

        /// <summary>
        /// 使用召唤包
        /// </summary>
        UseSummonBag = 0x48,

        /// <summary>
        /// 宠物食品
        /// </summary>
        PetFood = 0x49,

        /// <summary>
        /// 坐骑食品
        /// </summary>
        UseMountFood = 0x4A,

        // ---
        ScriptedItem = 0x4B,

        /// <summary>
        /// 使用现金物品
        /// </summary>
        UseCashItem = 0x4C,

        /// <summary>
        /// 使用捕捉物品
        /// </summary>
        UseCatchItem = 0x4D,

        /// <summary>
        /// 使用技能书
        /// </summary>
        UseSkillBook = 0x4F,

        /// <summary>
        /// 使用回城卷
        /// </summary>
        UseReturnScroll = 0x52,

        /// <summary>
        /// 使用卷轴
        /// </summary>
        UseUpgradeScroll = 0x53,

        /// <summary>
        /// 分配能力点
        /// </summary>
        DistributeAp = 0x54,

        /// <summary>
        /// 自动分配能力点
        /// </summary>
        DistributeAutoAp = 0x55,

        /// <summary>
        /// 自动回复HP/MP
        /// </summary>
        HealOverTime = 0x56,

        /// <summary>
        /// 分配技能点
        /// </summary>
        DistributeSp = 0x57,

        /// <summary>
        /// 特殊移动
        /// </summary>
        SpecialMove = 0x58,

        /// <summary>
        /// 取消增益效果
        /// </summary>
        CancelBuff = 0x59,

        /// <summary>
        /// 技能效果
        /// </summary>
        SkillEffect = 0x5A,

        /// <summary>
        /// 金币掉落
        /// </summary>
        MesoDrop = 0x5B,

        /// <summary>
        /// 给人气
        /// </summary>
        GiveFame = 0x5C,

        /// <summary>
        /// TODO:请求人物信息
        /// </summary>
        CharInfoRequest = 0x5E,

        /// <summary>
        /// 召唤宠物
        /// </summary>
        SpawnPet = 0x5F,

        /// <summary>
        /// 取消负面效果
        /// </summary>
        CancelDebuff = 0x60,

        /// <summary>
        /// 特殊地图移动
        /// </summary>
        ChangeMapSpecial = 0x61,

        /// <summary>
        /// 使用时空门
        /// </summary>
        UseInnerPortal = 0x62,

        /// <summary>
        /// 缩地石
        /// </summary>
        TrockAddMap = 0x63,

        /// <summary>
        /// 技能宏
        /// </summary>
        SkillMacro = 0x66,

        /// <summary>
        /// 钓鱼
        /// </summary>
        UseFishingItem = 0x67,

        /// <summary>
        /// 任务动作
        /// </summary>
        QuestAction = 0x68,

        /// <summary>
        /// 效果开关
        /// </summary>
        EffectOnOff = 0x69,

        /// <summary>
        /// TODO: 丢炸弹？
        /// </summary>
        ThrowBomb = 0xFF,

        /// <summary>
        /// TODO: 举报玩家
        /// </summary>
        ReportPlayer = 0xFF,

        /// <summary>
        /// 锻造技能
        /// </summary>
        MakerSkill = 0x71,

        /// <summary>
        /// 组队/家族聊天
        /// </summary>
        MultiChat = 0x74,

        /// <summary>
        /// 悄悄话
        /// </summary>
        Whisper = 0x75,

        /// <summary>
        /// 聊天招待
        /// </summary>
        Messenger = 0x76,

        /// <summary>
        /// TODO: 配偶聊天
        /// </summary>
        SpouseChat = 0xFF,

        /// <summary>
        /// 玩家互动
        /// </summary>
        PlayerInteraction = 0x77,

        /// <summary>
        /// 开设组队
        /// </summary>
        PartyOperation = 0x78,

        /// <summary>
        /// 拒绝组队邀请
        /// </summary>
        DenyPartyRequest = 0x79,

        /// <summary>
        /// 开设家族
        /// </summary>
        GuildOperation = 0x7A,

        /// <summary>
        /// 拒绝家族邀请
        /// </summary>
        DenyGuildRequest = 0x7B,

        /// <summary>
        /// 好友操作
        /// </summary>
        BuddylistModify = 0x7E,

        /// <summary>
        /// 小纸条
        /// </summary>
        NoteAction = 0x7F,

        /// <summary>
        /// 使用门
        /// </summary>
        UseDoor = 0x81,

        /// <summary>
        /// 改变键盘布局
        /// </summary>
        ChangeKeymap = 0x83,

        /// <summary>
        /// 戒指
        /// </summary>
        RingAction = 0x85,

        /// <summary>
        /// 家族联盟
        /// </summary>
        AllianceOperation = 0x89,

        /// <summary>
        /// 家族BBS
        /// </summary>
        BbsOperation = 0xFF,

        /// <summary>
        /// TODO: 进入拍卖
        /// </summary>
        EnterMts = 0x8D,

        /// <summary>
        /// TODO: 所罗门？
        /// </summary>
        Solomon = 0xFF,

        /// <summary>
        /// 打开学院
        /// </summary>
        OpenFamily = 0x91,

        /// <summary>
        /// 添加学院
        /// </summary>
        AddFamily = 0x92,

        /// <summary>
        /// TODO: 接收家族邀请
        /// </summary>
        AcceptFamily = 0x93,

        /// <summary>
        /// TODO: ?
        /// </summary>
        UseFamily = 0x94,


        /// <summary>
        /// 召唤兽说话
        /// </summary>
        SummonTalk = 0x9E,

        /// <summary>
        /// 战神伤害
        /// </summary>
        MobDamaged = 0x9F,


        /// <summary>
        /// 宠物移动
        /// </summary>
        MovePet = 0xA5,

        /// <summary>
        /// 宠物自动吃药
        /// </summary>
        PetAutoPot = 0x90,

        /// <summary>
        /// 宠物说话
        /// </summary>
        PetChat = 0xA6,

        /// <summary>
        /// 宠物命令
        /// </summary>
        PetCommand = 0xA7,

        /// <summary>
        /// 宠物拣取
        /// </summary>
        PetLoot = 0xA8,


        /// <summary>
        /// 召唤兽移动
        /// </summary>
        MoveSummon = 0xAD,

        /// <summary>
        /// 召唤兽动作
        /// </summary>
        SummonAttack = 0xAE,

        /// <summary>
        /// 召唤兽伤害
        /// </summary>
        DamageSummon = 0xB0,

        /// <summary>
        /// 怪物移动
        /// </summary>
        MoveLife = 0xB7,

        /// <summary>
        /// 自动攻击
        /// </summary>
        AutoAggro = 0xB8,

        /// <summary>
        /// TODO
        /// </summary>
        MobDamageMob = 0xBD,

        /// <summary>
        /// 怪物炸弹
        /// </summary>
        MonsterBomb = 0xBC,


        /// <summary>
        /// NPC说话
        /// </summary>
        NpcAction = 0xC0,

        /// <summary>
        /// 拣起物品
        /// </summary>
        ItemPickup = 0xC6,

        /// <summary>
        /// 伤害反映
        /// </summary>
        DamageReactor = 0xC9,

        /// <summary>
        /// 碰触反映
        /// </summary>
        TouchReactor = 0xCA,

        /// <summary>
        /// TODO: 催眠？
        /// </summary>
        Hypnotize = 0xFF,

        /// <summary>
        /// 怪物嘉年华
        /// </summary>
        MonsterCarnival = 0xFF,

        /// <summary>
        /// 地图状态
        /// </summary>
        ObjectRequest = 0xD7,

        /// <summary>
        /// 组队搜索请求
        /// </summary>
        PartySearchRegister = 0xD9,

        /// <summary>
        /// TODO: 开始搜索组队
        /// </summary>
        PartySearchStart = 0xDA,

        /// <summary>
        /// 人物数据更新
        /// </summary>
        PlayerUpdate = 0xE0,

        /// <summary>
        /// 金锤子
        /// </summary>
        ViciousHammer = 0xFF,

        /// <summary>
        /// TODO: 点卷确认
        /// </summary>
        TouchingCs = 0xE8,

        /// <summary>
        /// 购买物品
        /// </summary>
        CashShop = 0xE9,

        /// <summary>
        /// 使用兑换券
        /// </summary>
        Coupon = 0xEA,

        /// <summary>
        /// 冒险岛TV
        /// </summary>
        MapleTv = 0xFF,

        /// <summary>
        /// 拍卖系统
        /// </summary>
        MtsOp = 0xFB,

        /// <summary>
        /// 聊天系统
        /// </summary>
        ChatRoomSystem = 0x104
    }
}