namespace Dango.MapleStory.Data
{
    /// <summary>
    /// 技能数据
    /// </summary>
    public sealed class SkillData : Data
    {
        /// <summary>
        /// TODO: 技能ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// TODO: 技能等级
        /// </summary>
        public byte Level { get; set; }

        /// <summary>
        /// 最大能攻击怪物的数量
        /// </summary>
        public byte MobCount { get; set; }

        /// <summary>
        /// 攻击次数
        /// </summary>
        public byte HitCount { get; set; }

        /// <summary>
        /// 攻击范围
        /// </summary>
        public ushort Range { get; set; }

        /// <summary>
        /// 攻击持续时间
        /// </summary>
        public int Duration { get; set; }

        /// <summary>
        /// 魔量消耗
        /// </summary>
        public ushort MPCost { get; set; }

        /// <summary>
        /// 血量消耗
        /// </summary>
        public byte HPCost { get; set; }

        /// <summary>
        /// 伤害
        /// </summary>
        public ushort Damage { get; set; }

        /// <summary>
        /// 固定伤害
        /// </summary>
        public byte FixedDamage { get; set; }

        /// <summary>
        /// TODO: 暴击伤害
        /// </summary>
        public byte CriticalDamage { get; set; }

        /// <summary>
        /// TODO: 精通
        /// </summary>
        public byte Mastery { get; set; }

        /// <summary>
        /// TODO:
        /// </summary>
        public int OptionalItemCost { get; set; }

        /// <summary>
        /// TODO:
        /// </summary>
        public int ItemCost { get; set; }

        /// <summary>
        /// TODO:
        /// </summary>
        public byte ItemCount { get; set; }

        /// <summary>
        /// 消耗子弹数
        /// </summary>
        public byte BulletCost { get; set; }

        /// <summary>
        /// 消耗金钱数
        /// </summary>
        public ushort MoneyCost { get; set; }
        
        /// <summary>
        /// TODO:
        /// </summary>
        public int Parameter1 { get; set; }

        /// <summary>
        /// TODO:
        /// </summary>
        public int Parameter2 { get; set; }

        /// <summary>
        /// TODO: 速度增益
        /// </summary>
        public short Speed { get; set; }

        /// <summary>
        /// TODO: 跳跃力增益
        /// </summary>
        public byte Jump { get; set; }

        /// <summary>
        /// TODO: 力量增益
        /// </summary>
        public byte Strength { get; set; }

        /// <summary>
        /// TODO: 武器攻击力增益
        /// </summary>
        public short WeaponAttack { get; set; }

        /// <summary>
        /// TODO: 武器防御力增益
        /// </summary>
        public short WeaponDefense { get; set; }

        /// <summary>
        /// TODO: 魔法攻击力增益
        /// </summary>
        public short MagicAttack { get; set; }

        /// <summary>
        /// TODO: 魔法防御力增益
        /// </summary>
        public short MagicDefense { get; set; }

        /// <summary>
        /// TODO: 精准增益
        /// </summary>
        public byte Accuracy { get; set; }

        /// <summary>
        /// TODO: 闪避增益
        /// </summary>
        public byte Avoidance { get; set; }

        /// <summary>
        /// TODO: 血量增益
        /// </summary>
        public ushort HP { get; set; }

        /// <summary>
        /// TODO: 魔量增益
        /// </summary>
        public byte MP { get; set; }

        /// <summary>
        /// TODO:
        /// </summary>
        public byte Prop { get; set; }

        /// <summary>
        /// TODO:
        /// </summary>
        public ushort Morph { get; set; }

        /// <summary>
        /// TODO: 技能释放矩形范围顶点
        /// </summary>
        public short LeftTopX { get; set; }

        /// <summary>
        /// TODO: 技能释放矩形范围顶点
        /// </summary>
        public short LeftTopY { get; set; }

        /// <summary>
        /// TODO: 技能释放矩形范围顶点
        /// </summary>
        public short RightBottomX { get; set; }

        /// <summary>
        /// TODO: 技能释放矩形范围顶点
        /// </summary>
        public short RightBottomY { get; set; }

        /// <summary>
        /// 冷却时间
        /// </summary>
        public ushort Cooldown { get; set; }

        /// <summary>
        /// 判断是否与四转职业相关
        /// </summary>
        /// <param name="skillIdentifier">TODO:判断数</param>
        /// <returns></returns>
        public static bool IsFourthJobRelated(int skillIdentifier) => ((skillIdentifier / 10000) % 10) == 2;

        public override void Load(DataReader reader)
        {
            Id = reader.ReadInt32();
            Level = reader.ReadByte();
            MobCount = reader.ReadByte();
            HitCount = reader.ReadByte();
            Range = reader.ReadUInt16();
            Duration = reader.ReadInt32();
            MPCost = reader.ReadUInt16();
            HPCost = reader.ReadByte();
            Damage = reader.ReadUInt16();
            FixedDamage = reader.ReadByte();
            CriticalDamage = reader.ReadByte();
            Mastery = reader.ReadByte();
            OptionalItemCost = reader.ReadInt32();
            ItemCost = reader.ReadInt32();
            ItemCount = reader.ReadByte();
            BulletCost = reader.ReadByte();
            MoneyCost = reader.ReadUInt16();
            Parameter1 = reader.ReadInt32();
            Parameter2 = reader.ReadInt32();
            Speed = reader.ReadInt16();
            Jump = reader.ReadByte();
            Strength = reader.ReadByte();
            WeaponAttack = reader.ReadInt16();
            WeaponDefense = reader.ReadInt16();
            MagicAttack = reader.ReadInt16();
            MagicDefense = reader.ReadInt16();
            Accuracy = reader.ReadByte();
            Avoidance = reader.ReadByte();
            HP = reader.ReadUInt16();
            MP = reader.ReadByte();
            Prop = reader.ReadByte();
            Morph = reader.ReadUInt16();
            LeftTopX = reader.ReadInt16();
            LeftTopY = reader.ReadInt16();
            RightBottomX = reader.ReadInt16();
            RightBottomY = reader.ReadInt16();
            Cooldown = reader.ReadUInt16();
        }

        public override void Save(DataWriter writer)
        {
            writer.Write(Id);
            writer.Write(Level);
            writer.Write(MobCount);
            writer.Write(HitCount);
            writer.Write(Range);
            writer.Write(Duration);
            writer.Write(MPCost);
            writer.Write(HPCost);
            writer.Write(Damage);
            writer.Write(FixedDamage);
            writer.Write(CriticalDamage);
            writer.Write(Mastery);
            writer.Write(OptionalItemCost);
            writer.Write(ItemCost);
            writer.Write(ItemCount);
            writer.Write(BulletCost);
            writer.Write(MoneyCost);
            writer.Write(Parameter1);
            writer.Write(Parameter2);
            writer.Write(Speed);
            writer.Write(Jump);
            writer.Write(Strength);
            writer.Write(WeaponAttack);
            writer.Write(WeaponDefense);
            writer.Write(MagicAttack);
            writer.Write(MagicDefense);
            writer.Write(Accuracy);
            writer.Write(Avoidance);
            writer.Write(HP);
            writer.Write(MP);
            writer.Write(Prop);
            writer.Write(Morph);
            writer.Write(LeftTopX);
            writer.Write(LeftTopY);
            writer.Write(RightBottomX);
            writer.Write(RightBottomY);
            writer.Write(Cooldown);
        }
    }
}