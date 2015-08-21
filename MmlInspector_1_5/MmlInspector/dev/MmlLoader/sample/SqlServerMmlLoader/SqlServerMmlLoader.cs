using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace SqlServerMmlLoader
{
    public class SqlServerMmlLoader : Yos731.MmlLoader.IMmlLoader
    {
        public bool Load(out string mml, out string description)
        {
            mml = null;
            description = null;

            // 患者番号を入力するダイアログを表示
            PatientIdForm form = new PatientIdForm();

            // 患者番号の入力がキャンセルされた場合は終了
            if (System.Windows.Forms.DialogResult.OK != form.ShowDialog())
                return false;

            // SQL ServerからMMLドキュメントを取得
            // テスト用のDBを使用したサンプルですので、実際の環境に合わせて適宜変更してください。
            try
            {
                using (SqlConnection conn = new SqlConnection("server=localhost;database=MML_DB;user=user01;password=p&ssw0rd;"))
                {
                    conn.Open();

                    // テスト用のテーブルは、ID列以外はPateintID, Mmlの2個のカラムのみで、それぞれNullable=falseです。
                    using (SqlCommand command = new SqlCommand("SELECT TOP 1 Mml FROM History WHERE PatientID=@pid", conn))
                    {
                        command.Parameters.Add("@pid", SqlDbType.NChar).Value = form.PatientId;

                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                mml = (string)dr["Mml"];
                                description = "Patient ID: " + form.PatientId;
                                break;
                            }
                        }
                    }
                }

                if (mml == null)
                    throw new Yos731.MmlLoader.MmlLoaderException("データが存在しません。", null);
                else
                    return true;
            }
            catch (Exception e)
            {
                // エラーが発生した場合は、MmlLoaderExceptionをスローします。
                throw new Yos731.MmlLoader.MmlLoaderException("SqlServerMmlLoaderでエラーが発生しました。", e);
            }
        }
    }
}
