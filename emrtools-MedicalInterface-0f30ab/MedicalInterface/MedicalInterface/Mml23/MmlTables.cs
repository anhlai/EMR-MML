using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace MedicalInterface.Mml23 {

    public class MmlTableManager {

        /// <summary>
        /// チェックディジット方式
        /// </summary>
        public MmlTable Mml0001 { get; set; }

        /// <summary>
        /// 住所区分
        /// </summary>
        public MmlTable Mml0002 { get; set; }

        /// <summary>
        /// 電話番号区分
        /// </summary>
        public MmlTable Mml0003 { get; set; }

        /// <summary>
        /// 抽出基準
        /// </summary>
        public MmlTable Mml0004 { get; set; }

        /// <summary>
        /// 記載内容モジュールの種別
        /// </summary>
        public MmlTable Mml0005 { get; set; }

        /// <summary>
        /// アクセス権者
        /// </summary>
        public MmlTable Mml0006 { get; set; }

        /// <summary>
        /// 文書詳細種別
        /// </summary>
        public MmlTable Mml0007 { get; set; }

        /// <summary>
        /// 関連文書との関係
        /// </summary>
        public MmlTable Mml0008 { get; set; }

        /// <summary>
        /// その他のID種別
        /// </summary>
        public MmlTable Mml0009 { get; set; }

        /// <summary>
        /// 性別
        /// </summary>
        public MmlTable Mml0010 { get; set; }

        /// <summary>
        /// 婚姻状態
        /// </summary>
        public MmlTable Mml0011 { get; set; }

        /// <summary>
        /// Diagnosis category 1
        /// 主病名区分
        /// </summary>
        public MmlTable Mml0012 { get; set; }

        /// <summary>
        /// Diagnosis category 2
        /// 診断・医事区分
        /// </summary>
        public MmlTable Mml0013 { get; set; }

        /// <summary>
        /// Diagnosis category 3
        /// 診断分類
        /// </summary>
        public MmlTable Mml0014 { get; set; }

        /// <summary>
        /// Diagnosis category 4
        /// 疑い・確定区分
        /// </summary>
        public MmlTable Mml0015 { get; set; }

        /// <summary>
        /// 病名転帰
        /// </summary>
        public MmlTable Mml0016 { get; set; }

        /// <summary>
        /// アレルギー反応程度
        /// </summary>
        public MmlTable Mml0017 { get; set; }

        /// <summary>
        /// ABO式血液型
        /// </summary>
        public MmlTable Mml0018 { get; set; }

        /// <summary>
        /// Rho(D)式血液型
        /// </summary>
        public MmlTable Mml0019 { get; set; }

        /// <summary>
        /// 続柄
        /// </summary>
        public MmlTable Mml0020 { get; set; }

        /// <summary>
        /// 手術区分
        /// </summary>
        public MmlTable Mml021 { get; set; }

        /// <summary>
        /// 手術スタッフ区分
        /// </summary>
        public MmlTable Mml0022 { get; set; }

        /// <summary>
        /// 麻酔医区分
        /// </summary>
        public MmlTable Mml0023 { get; set; }

        /// <summary>
        /// ID区分
        /// </summary>
        public MmlTable Mml0024 { get; set; }

        /// <summary>
        /// 表記コード
        /// </summary>
        public MmlTable Mml0025 { get; set; }

        /// <summary>
        /// 記録者分類および医療資格コード
        /// </summary>
        public MmlTable Mml0026 { get; set; }

        /// <summary>
        /// 施設ID区分
        /// </summary>
        public MmlTable Mml0027 { get; set; }

        /// <summary>
        /// 医科診療科コード
        /// </summary>
        public MmlTable Mml0028 { get; set; }

        /// <summary>
        /// 医科歯科区分
        /// </summary>
        public MmlTable Mml0029 { get; set; }

        /// <summary>
        /// 歯科診療科コード
        /// </summary>
        public MmlTable Mml0030 { get; set; }

        /// <summary>
        /// 保険種別
        /// </summary>
        public MmlTable Mml0031 { get; set; }

        /// <summary>
        /// 負担方法コード
        /// </summary>
        public MmlTable Mml0032 { get; set; }

        /// <summary>
        /// Medical Role
        /// </summary>
        public MmlTable Mml0033 { get; set; }

        /// <summary>
        /// アクセス許可区分
        /// </summary>
        public MmlTable Mml0034 { get; set; }

        /// <summary>
        /// 施設アクセス権定義
        /// </summary>
        public MmlTable Mml0035 { get; set; }

        /// <summary>
        /// 個人アクセス権定義
        /// </summary>
        public MmlTable Mml0036 { get; set; }

        /// <summary>
        /// 時間外区分
        /// </summary>
        public MmlTable Claim001 { get; set; }

        /// <summary>
        /// 診療行為区分コード
        /// </summary>
        public MmlTable Claim002 { get; set; }

        /// <summary>
        /// 診療種別区分
        /// </summary>
        public MmlTable Claim003 { get; set; }

        /// <summary>
        /// 数量コード
        /// </summary>
        public MmlTable Claim004 { get; set; }

        /// <summary>
        /// フイルムサイズコード
        /// </summary>
        public MmlTable Claim005 { get; set; }

        /// <summary>
        /// 用法コード
        /// </summary>
        public MmlTable Claim006 { get; set; }

        /// <summary>
        /// レセ電算診療行為区分コード
        /// </summary>
        public MmlTable Claim007 { get; set; }

        /// <summary>
        /// 状態
        /// </summary>
        public MmlTable Claim008 { get; set; }

        /// <summary>
        /// 予約
        /// </summary>
        public MmlTable Claim009 { get; set; }

        public MmlTableManager() {
            Claim001 = new MmlTable();
        }
    }

    public class MmlTable {

        public string TableId { get; set; }

        public string Comment { get; set; }

        public List<MmlTableItem> ItemList { get; set; }

        public MmlTable() {
            this.ItemList = new List<MmlTableItem>();
        }

        public string GetDescription(string val) {
            var rows = from itm in this.ItemList where itm.Value == val select itm;
            if (rows.Count<MmlTableItem>() > 0) {
                return rows.First<MmlTableItem>().Description;
            } else {
                return "";
            }
        }

    }

    public class MmlTableItem {

        public string Value { get; set; }

        public string Description { get; set; }

        public string Comment { get; set; }

        public MmlTableItem() {

        }
    }
}
