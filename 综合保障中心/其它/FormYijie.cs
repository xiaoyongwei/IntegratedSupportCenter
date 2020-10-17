using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using 综合保障中心.Comm;
using System.IO;

namespace 综合保障中心.其它
{
    public partial class FormYijie : Form
    {
        private enum WebAfter
        {
            无,
            登录,
            保存,
            获取关联信息,
            彩印维护_初步,
            数码维护_初步_循环,
            数码维护_初步_单个,
            彩印维护_精准_循环,
            彩印维护_精准_单个,
            数码维护_精准_循环,
            数码维护_精准_单个,
            获取二期库存列表,
            运费管理
        }
        /// <summary>
        /// 浏览器加载后执行的动作
        /// </summary>
        private WebAfter wAfter = WebAfter.无;

        public FormYijie()
        {
            InitializeComponent();
        }

        private void 前往ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!textBoxUrl.Text.StartsWith("http://",StringComparison.OrdinalIgnoreCase))
            {
                textBoxUrl.Text = "http://" + textBoxUrl.Text;
            }
            webBrowser.Navigate(this.textBoxUrl.Text.Trim());
        }

        private void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            this.contextMenuStrip1.Items.Clear();
            foreach (HtmlElement he in webBrowser.Document.All)
            {
                //添加按钮
                string type = he.GetAttribute("type");
                if (type.Equals("submit",StringComparison.OrdinalIgnoreCase)||type.Equals("button",StringComparison.OrdinalIgnoreCase))
                {
                    ToolStripMenuItem tsmi = new ToolStripMenuItem(he.GetAttribute("value"));
                    tsmi.Click+= new EventHandler(tsmi_Click);
                    this.contextMenuStrip1.Items.Add(tsmi);
                }
            }
            //复制当前网址
            ToolStripMenuItem tsmiUrl = new ToolStripMenuItem("复制当前网址");
            tsmiUrl.Click += new EventHandler(tsmiUrl_Click);
            this.contextMenuStrip1.Items.Add(tsmiUrl);

            this.textBoxUrl.Text = webBrowser.Url.ToString();

            //加载完成后的操作
            switch (wAfter)
            {
                case WebAfter.无:
                    break;
                case WebAfter.登录:
                    WebLogin();
                    break;
                case WebAfter.保存:
                    break;
                case WebAfter.获取关联信息:
                    break;
                case WebAfter.彩印维护_初步:
                    break;
                case WebAfter.数码维护_初步_循环:
                    break;
                case WebAfter.数码维护_初步_单个:
                    break;
                case WebAfter.彩印维护_精准_循环:
                    break;
                case WebAfter.彩印维护_精准_单个:
                    break;
                case WebAfter.数码维护_精准_循环:
                    break;
                case WebAfter.数码维护_精准_单个:
                    break;
                case WebAfter.获取二期库存列表:                    
                    GetErqiCangku();
                    break;
                case WebAfter.运费管理:
                    YunfeiGuanli();
                    break;
                default:
                    break;
            }
        }

        private void YunfeiGuanli()
        {
            throw new NotImplementedException();
        }

        private void GetErqiCangku()
        {
            List<string> sqlList = new List<string>();
            List<string> gdhList = new List<string>();
            string[] htmlArray = webBrowser.DocumentText.Replace("\t", "").Replace(" ", "").Replace("\n","").Split('\r');
            for (int i = 0; i < htmlArray.Length; i++)
            {
                if (Regex.IsMatch(htmlArray[i], "<td>.*二期.*</td>")
                    && Regex.IsMatch(htmlArray[i+1], "<td>(C|Z|A)\\d+</td>",RegexOptions.IgnoreCase))
                {
                    gdhList.Add(htmlArray[i+1].Trim("</td>".ToArray()));
                }
            }
            foreach (string gdh in gdhList)
            {
                sqlList.Add(string.Format("INSERT IGNORE INTO `仓库`.`成品_二期仓库工单`(`工单号`)VALUES('{0}');", gdh));
            }
            MySqlDbHelper.ExecuteSqlTran(sqlList);
            wAfter = WebAfter.无;
        }

        void tsmiUrl_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(webBrowser.Url.ToString());
        }


        void tsmi_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem tsmi = sender as ToolStripMenuItem;
            string text = tsmi.Text;
            foreach (HtmlElement he in webBrowser.Document.All)
            {
                string type = he.GetAttribute("type");
                string value = he.GetAttribute("value");
                if ((type.Equals("submit",StringComparison.OrdinalIgnoreCase)||type.Equals("button",StringComparison.OrdinalIgnoreCase))
                    && value.Equals(text, StringComparison.OrdinalIgnoreCase))
                {
                    wAfter = WebAfter.无;
                    he.InvokeMember("click");
                    return;
                }
            }



        }

        private void FormYijiePojie_Load(object sender, EventArgs e)
        {            

            InitTreeNode();

            GotoWebUrl("http://21.ej-sh.net:9191/login.shtml?method:exit", WebAfter.无);
        }

        private void InitTreeNode()
        {
            treeView1.Nodes.Clear();
            List<string> tnList = new List<string>();
            tnList.Add("系统维护,");            
            tnList.Add("部门维护,http://21.ej-sh.net:9191/pbDept.shtml");
            tnList.Add("动态报表,http://21.ej-sh.net:9191/pbDsql.shtml");
            tnList.Add("用户维护,http://21.ej-sh.net:9191/sysUser.shtml");
            tnList.Add("角色维护,http://21.ej-sh.net:9191/sysRole.shtml");
            tnList.Add("组织机构,http://21.ej-sh.net:9191/sysOrgn.shtml");
            tnList.Add("系统作业,http://21.ej-sh.net:9191/pbTask.shtml");
            tnList.Add("机构变量,http://21.ej-sh.net:9191/pbItem.shtml");
            tnList.Add("规则维护,http://21.ej-sh.net:9191/pbRule.shtml");
            tnList.Add("自定规则,http://21.ej-sh.net:9191/pbRule/edit.shtml");
            tnList.Add("菜单管理,http://21.ej-sh.net:9191/sysMenu.shtml");
            tnList.Add("系统日志,http://21.ej-sh.net:9191/sysLogs.shtml");
            tnList.Add("系统维护,http://21.ej-sh.net:9191/sysPatch.shtml");
            tnList.Add("消息管理,http://21.ej-sh.net:9191/pbIms.shtml");
            tnList.Add("月结管理,http://21.ej-sh.net:9191/pbMnth.shtml");
            tnList.Add("区域维护 ,http://21.ej-sh.net:9191/pbArea.shtml");
            tnList.Add("集团管理,");
            tnList.Add("集团客户,http://21.ej-sh.net:9191/pbGroup.shtml?curorg=N");
            tnList.Add("材质定义,http://21.ej-sh.net:9191/mkCb/bp.shtml");
            tnList.Add("做报价单,http://21.ej-sh.net:9191/mkCb/lp.shtml");
            tnList.Add("自助设价,http://21.ej-sh.net:9191/mkCb/self.shtml");
            tnList.Add("统一折扣,http://21.ej-sh.net:9191/mkCb/rebate.shtml");
            tnList.Add("集团销售员,http://21.ej-sh.net:9191/pbEmps/ag.shtml");
            tnList.Add("集团跟单员 ,http://21.ej-sh.net:9191/pbEmps/as.shtml");
            tnList.Add("人事档案,");
            tnList.Add("员工信息,http://21.ej-sh.net:9191/hrBase.shtml?fstyle=Sl");
            tnList.Add("请假管理,http://21.ej-sh.net:9191/hrAbsence.shtml");
            tnList.Add("计件数据,http://21.ej-sh.net:9191/hrPieceData.shtml");
            tnList.Add("计件查询,http://21.ej-sh.net:9191/hrWagePiece.shtml");
            tnList.Add("工作信息,http://21.ej-sh.net:9191/hrJobs.shtml");
            tnList.Add("工作汇报,http://21.ej-sh.net:9191/oaWork.shtml");
            tnList.Add("废纸外卖,http://21.ej-sh.net:9191/pbWastePaper.shtml");
            tnList.Add("车辆定位,http://21.ej-sh.net:9191/pbTask.shtml?method:gps");
            tnList.Add("视频监控,http://21.ej-sh.net:9191/pbTask.shtml?method:monitor");
            tnList.Add("视频培训,http://21.ej-sh.net:9191/msPlay.shtml");
            tnList.Add("快递登记,http://21.ej-sh.net:9191/pbExps.shtml");
            tnList.Add("报工查询,http://21.ej-sh.net:9191/ordSchCt/overlist.shtml");
            tnList.Add("APP版报工,http://21.ej-sh.net:9191/mbOrd/scan.shtml");
            tnList.Add("车间报工 ,http://21.ej-sh.net:9191/hrPieceData/scan.shtml");
            tnList.Add("绩效管理,");
            tnList.Add("KPI考核,http://21.ej-sh.net:9191/hrKpiMnth.shtml");
            tnList.Add("积分管理,http://21.ej-sh.net:9191/hrWagePerf.shtml?status=N");
            tnList.Add("指标库 ,http://21.ej-sh.net:9191/hrQuota.shtml");
            tnList.Add("销售市场,");
            tnList.Add("销售订单,http://21.ej-sh.net:9191/mbMk.shtml?fstyle=");
            tnList.Add("财务信息,http://21.ej-sh.net:9191/ctClnt/fin.shtml");
            tnList.Add("错单备注,http://21.ej-sh.net:9191/mbMk/listu.shtml");
            tnList.Add("潜在客户,http://21.ej-sh.net:9191/mkClnt.shtml");
            tnList.Add("业务拜访,http://21.ej-sh.net:9191/mkVisit.shtml");
            tnList.Add("水印报价,http://21.ej-sh.net:9191/mkPq/ct.shtml");
            tnList.Add("彩印报价,http://21.ej-sh.net:9191/mkPq/cl.shtml?objtyp=&fstyle=Sl");
            tnList.Add("报价模板,http://21.ej-sh.net:9191/mkPqBase.shtml");
            tnList.Add("销售计划,http://21.ej-sh.net:9191/mkPlan/mk.shtml");
            tnList.Add("回款计划,http://21.ej-sh.net:9191/mkPlanAr.shtml");
            tnList.Add("销售进度,http://21.ej-sh.net:9191/mkPlan/bi.shtml?method:birate");
            tnList.Add("业务转移,http://21.ej-sh.net:9191/ctClnt/agnt.shtml");
            tnList.Add("分派客户,http://21.ej-sh.net:9191/mkClnt.shtml?method:elst");
            tnList.Add("销售分析,http://21.ej-sh.net:9191/biMk.shtml");
            tnList.Add("纸箱报价 ,http://21.ej-sh.net:9191/mkPq/cl.shtml?objtyp=CT");
            tnList.Add("工艺技术,");
            tnList.Add("往来单位,http://21.ej-sh.net:9191/pbClnt.shtml?method:list");
            tnList.Add("水印档案,http://21.ej-sh.net:9191/ctPrd.shtml?fid=Y&amp;fstyle=Sl");
            tnList.Add("彩印档案,http://21.ej-sh.net:9191/clPrd.shtml?fid=Y&fstyle=Sl");
            tnList.Add("纸板档案,http://21.ej-sh.net:9191/cbPrd.shtml");
            tnList.Add("价格维护,http://21.ej-sh.net:9191/ctPrd/pc.shtml");
            tnList.Add("工序维护,http://21.ej-sh.net:9191/pbProcesses.shtml");
            tnList.Add("班组管理,http://21.ej-sh.net:9191/pbTeam.shtml");
            tnList.Add("瓦楞设置,http://21.ej-sh.net:9191/pbCorrugate.shtml");
            tnList.Add("设备管理,http://21.ej-sh.net:9191/pbMachine.shtml");
            tnList.Add("设备维护,http://21.ej-sh.net:9191/schMacSvc.shtml");
            tnList.Add("设备运作,http://21.ej-sh.net:9191/schMacWok.shtml");
            tnList.Add("箱型管理,http://21.ej-sh.net:9191/pbType.shtml");
            tnList.Add("印版管理,http://21.ej-sh.net:9191/pbPlate/ppsl.shtml");
            tnList.Add("模版管理,http://21.ej-sh.net:9191/pbPlate/sl.shtml");
            tnList.Add("模板管理,http://21.ej-sh.net:9191/pbPlate/sl.shtml");
            tnList.Add("印版管理 ,http://21.ej-sh.net:9191/pbPlate/ppsl.shtml");
            tnList.Add("计划物流,");
            tnList.Add("客户信用,http://21.ej-sh.net:9191/ordInquiry/clntcred.shtml");
            tnList.Add("订单信用,http://21.ej-sh.net:9191/ordInquiry/cred.shtml");
            tnList.Add("纸板订单,http://21.ej-sh.net:9191/cbOrd/mt.shtml?fstyle=Sl");
            tnList.Add("彩印维护,http://21.ej-sh.net:9191/clOrd/mt.shtml?fstyle=Sl&amp;fid=Y");
            tnList.Add("商务维护,http://21.ej-sh.net:9191/cmOrd/mt.shtml?fstyle=Sl&amp;fid=Y");
            tnList.Add("修改交期,http://21.ej-sh.net:9191/ordInquiry/cs.shtml");
            tnList.Add("数码平板,http://21.ej-sh.net:9191/ccOrd/mt.shtml");
            tnList.Add("数码维护,http://21.ej-sh.net:9191/cdOrd/mt.shtml?fstyle=Sl&fid=Y");
            tnList.Add("订单改价,http://21.ej-sh.net:9191/ordInquiry/cp.shtml");
            tnList.Add("排产审核,http://21.ej-sh.net:9191/ordSchCt/sl.shtml?status=2&amp;prctyp=04");
            tnList.Add("纸板审核,http://21.ej-sh.net:9191/cbOrd/ad.shtml?id=");
            tnList.Add("排程分析,http://21.ej-sh.net:9191/ordAnalysis.shtml");
            tnList.Add("纸板分析,http://21.ej-sh.net:9191/ordAnalysis.shtml?method:list2=");
            tnList.Add("排程管理,http://21.ej-sh.net:9191/ordSchCt.shtml");
            tnList.Add("纸板排程,http://21.ej-sh.net:9191/ordSchZb.shtml");
            tnList.Add("彩印排程,http://21.ej-sh.net:9191/ordSchCl.shtml");
            tnList.Add("排程查询,http://21.ej-sh.net:9191/ordSchRead.shtml");
            tnList.Add("综合查询,http://21.ej-sh.net:9191/ordInquiry/sl.shtml");
            tnList.Add("订单跟踪,http://21.ej-sh.net:9191/ordInquiry/tr.shtml?method:trsrlist=");
            tnList.Add("车辆维护,http://21.ej-sh.net:9191/pbAuto.shtml");
            tnList.Add("排车审后修改,http://21.ej-sh.net:9191/dlvAuto/chng.shtml");
            tnList.Add("箱片排车,http://21.ej-sh.net:9191/dlvAuto.shtml?status=N&amp;fstyle=Sl&objtyp=CB");
            tnList.Add("纸箱排车,http://21.ej-sh.net:9191/dlvAuto.shtml?status=N&amp;fstyle=Sl&amp;objtyp=ZX");
            tnList.Add("运费管理,http://21.ej-sh.net:9191/dlvFare/sl.shtml");
            tnList.Add("运费结算,http://21.ej-sh.net:9191/dlvFare.shtml");
            tnList.Add("胶印排程,http://21.ej-sh.net:9191/ordSchCt/sl.shtml?status=3&amp;prctyp=04");
            tnList.Add("覆膜排程,http://21.ej-sh.net:9191/ordSchCt/fm.shtml?status=3&amp;prctyp=06");
            tnList.Add("过油排程,http://21.ej-sh.net:9191/ordSchCt/uv.shtml?status=3&amp;prctyp=14");
            tnList.Add("甩纸确认,http://21.ej-sh.net:9191/ordSchCt/bcp.shtml?status=N");
            tnList.Add("切纸确认,http://21.ej-sh.net:9191/ordSchCt/cut.shtml?status=N");
            tnList.Add("印版确认,http://21.ej-sh.net:9191/ordSchCt/plt.shtml?status=N");
            tnList.Add("油墨确认,http://21.ej-sh.net:9191/ordSchCt/ink.shtml?status=N");
            tnList.Add("制板排程,http://21.ej-sh.net:9191/ordSchCt.shtml?fstyle=Sl&amp;status=2&amp;prctyp=01&suprc=");
            tnList.Add("后道排程,http://21.ej-sh.net:9191/ordSchCt/su.shtml?selected=Y");
            tnList.Add("工单修改,http://21.ej-sh.net:9191/clOrd/sp.shtml?fstyle=Sl&fid=Y");
            tnList.Add("森林通用工序统计,http://21.ej-sh.net:9191/procstats.shtml");
            tnList.Add("平方改价 ,http://21.ej-sh.net:9191/ordInquiry/incp.shtml");
            tnList.Add("原纸管理,");
            tnList.Add("纸卷厂商,http://21.ej-sh.net:9191/bpClnt.shtml");
            tnList.Add("纸卷档案,http://21.ej-sh.net:9191/bpPrd.shtml");
            tnList.Add("综合查询 ,http://21.ej-sh.net:9191/bpInquiry.shtml");
            tnList.Add("成品仓库,");
            tnList.Add("扫描入库,http://21.ej-sh.net:9191/ctBcdr/ro.shtml");
            tnList.Add("返修（退车间）,http://21.ej-sh.net:9191/ctBcdr/rg.shtml");
            tnList.Add("批次入库,http://21.ej-sh.net:9191/ctBcdr/ra.shtml");
            tnList.Add("退货入库,http://21.ej-sh.net:9191/ctBcdx/xt.shtml");
            tnList.Add("批次退货入库,http://21.ej-sh.net:9191/ctBcdx/xp.shtml");
            tnList.Add("销售退货,http://21.ej-sh.net:9191/ctBcdx/xl.shtml");
            tnList.Add("产品报废,http://21.ej-sh.net:9191/ctBcdx/xc.shtml");
            tnList.Add("异常出库（报损）,http://21.ej-sh.net:9191/ctBcdx/xm.shtml");
            tnList.Add("成品整理,http://21.ej-sh.net:9191/ctInquiry/du.shtml");
            tnList.Add("综合查询,http://21.ej-sh.net:9191/ctInquiry.shtml?method:bcdt=");
            tnList.Add("销售出货,http://21.ej-sh.net:9191/ctBcdx/xa.shtml");
            tnList.Add("销售中心查询,http://21.ej-sh.net:9191/ctBcdx/dl.shtml");
            tnList.Add("销售中心查询,http://21.ej-sh.net:9191/ctBcdx/xr.shtml");
            tnList.Add("送货回签,http://21.ej-sh.net:9191/ctBcdx/sl.shtml");
            tnList.Add("销售中心退货,http://21.ej-sh.net:9191ctBcdx/xl.shtml");
            tnList.Add("销售查询,http://21.ej-sh.net:9191/ctBcdx/gl.shtml");
            tnList.Add("温岭地址查询,http://21.ej-sh.net:9191/dlvAuto.shtml?status=N&amp;fstyle=Sl&amp;objtyp=WL");
            tnList.Add("排车查询 ,http://21.ej-sh.net:9191/ctBcdx/dlv.shtml");
            tnList.Add("半成品库,");
            tnList.Add("综合查询,http://21.ej-sh.net:9191/spInquiry.shtml");
            tnList.Add("入半成品,http://21.ej-sh.net:9191/spBcdr/rp.shtml");
            tnList.Add("出半成品 ,http://21.ej-sh.net:9191/spBcdx/xp.shtml");
            tnList.Add("辅料仓库,");
            tnList.Add("供 应 商,http://21.ej-sh.net:9191/atClnt.shtml");
            tnList.Add("辅料产品,http://21.ej-sh.net:9191/atPrd.shtml");
            tnList.Add("采购申请,http://21.ej-sh.net:9191/atStcm/pl.shtml");
            tnList.Add("辅料采购,http://21.ej-sh.net:9191/atStcm/rb.shtml");
            tnList.Add("审核入库,http://21.ej-sh.net:9191/atBcdr/ad.shtml");
            tnList.Add("采购收货,http://21.ej-sh.net:9191/atBcdr/rb.shtml");
            tnList.Add("采购退货,http://21.ej-sh.net:9191/atBcdr/rt.shtml");
            tnList.Add("辅料领用,http://21.ej-sh.net:9191/atBcdx/xp.shtml");
            tnList.Add("销售发货,http://21.ej-sh.net:9191/atBcdx/xs.shtml");
            tnList.Add("销售退货,http://21.ej-sh.net:9191/atBcdx/xt.shtml");
            tnList.Add("调拨入库,http://21.ej-sh.net:9191/atBcdr/rh.shtml");
            tnList.Add("调拨出库,http://21.ej-sh.net:9191/atBcdx/xh.shtml");
            tnList.Add("综合查询 ,http://21.ej-sh.net:9191/atInquiry.shtml?method:bcdtlist=");
            tnList.Add("纸板管理,");
            tnList.Add("供应商,http://21.ej-sh.net:9191/zbClnt.shtml");
            tnList.Add("纸板采购,http://21.ej-sh.net:9191/zbStcm/mt.shtml?status=N&amp;rptcde=ZbStcm03&fstyle=Sl");
            tnList.Add("纸板入库（批次）,http://21.ej-sh.net:9191/zbBcdr/ra.shtml");
            tnList.Add("纸板入库,http://21.ej-sh.net:9191/zbBcdr/rb.shtml");
            tnList.Add("纸板出库,http://21.ej-sh.net:9191/zbBcdx/xp.shtml");
            tnList.Add("综合查询 ,http://21.ej-sh.net:9191/zbInquiry.shtml?method:bcdt=");
            tnList.Add("应收管理,");
            tnList.Add("送货回签,http://21.ej-sh.net:9191/arBcdr/sz.shtml");
            tnList.Add("人工记帐,http://21.ej-sh.net:9191/arBcdr/ar.shtml");
            tnList.Add("多组织收款,http://21.ej-sh.net:9191/arBcdx/mo.shtml");
            tnList.Add("应收台帐,http://21.ej-sh.net:9191/arMnth.shtml?method:bcdj=");
            tnList.Add("应收发票,http://21.ej-sh.net:9191/arBill.shtml");
            tnList.Add("应收月结,http://21.ej-sh.net:9191/arMnth.shtml?method:mnth=");
            tnList.Add("应收汇总 ,http://21.ej-sh.net:9191/arMnth.shtml?method:bala=");
            tnList.Add("应付管理,");
            tnList.Add("收货记帐,http://21.ej-sh.net:9191/apBcdr/sz.shtml");
            tnList.Add("人工记帐,http://21.ej-sh.net:9191/apBcdr/ap.shtml");
            tnList.Add("业务支付,http://21.ej-sh.net:9191/apBcdx.shtml");
            tnList.Add("应付台帐,http://21.ej-sh.net:9191/apMnth.shtml?method:bcdj=");
            tnList.Add("应付发票,http://21.ej-sh.net:9191/apBill.shtml");
            tnList.Add("应付月结,http://21.ej-sh.net:9191/apMnth.shtml?method:mnth=");
            tnList.Add("应付汇总 ,http://21.ej-sh.net:9191/apMnth.shtml?method:bala=");
            tnList.Add("数据分析,");
            tnList.Add("指标分析,http://21.ej-sh.net:9191/biGain.shtml");
            tnList.Add("动态查询,http://21.ej-sh.net:9191/pbDsql/exp.shtml");
            tnList.Add("订单分析,http://21.ej-sh.net:9191/biOrd.shtml");
            tnList.Add("质量分析,http://21.ej-sh.net:9191/biQc.shtml");
            tnList.Add("成品分析,http://21.ej-sh.net:9191/biCt.shtml");
            tnList.Add("原纸分析,http://21.ej-sh.net:9191/biBp.shtml");
            tnList.Add("应收分析,http://21.ej-sh.net:9191/biAr.shtml?method:ar00");
            tnList.Add("企业概况 ,http://21.ej-sh.net:9191/biSummary.shtml");
            tnList.Add("报表荟萃,");
            tnList.Add("报价工序报表,http://21.ej-sh.net:9191/pbDsql/cust.shtml?sqlcde=R17100039");
            tnList.Add("排程明细表,http://21.ej-sh.net:9191/pbDsql/cust.shtml?sqlcde=R17100041");
            tnList.Add("排产完成率报表(纸箱),http://21.ej-sh.net:9191/pbDsql/cust.shtml?sqlcde=R17100042");
            tnList.Add("已排程明细表,http://21.ej-sh.net:9191/pbDsql/cust.shtml?sqlcde=R17100043");
            tnList.Add("新数码下单统计表,http://21.ej-sh.net:9191/pbDsql/cust.shtml?sqlcde=R18030079");
            tnList.Add("排车完成率报表,http://21.ej-sh.net:9191/pbDsql/cust.shtml?sqlcde=R17100046");
            tnList.Add("报价明细表,http://21.ej-sh.net:9191/pbDsql/cust.shtml?sqlcde=R17110047");
            tnList.Add("运费汇总表(按天),http://21.ej-sh.net:9191/pbDsql/cust.shtml?sqlcde=R17110049");
            tnList.Add("补单成本核算表(新厂),http://21.ej-sh.net:9191/pbDsql/cust.shtml?sqlcde=R17110050");
            tnList.Add("补单成本核算表(临海),http://21.ej-sh.net:9191/pbDsql/cust.shtml?sqlcde=R18040080");
            tnList.Add("新厂粘钉箱统计表 ,http://21.ej-sh.net:9191/pbDsql/cust.shtml?sqlcde=R18080091");


            foreach (string item in tnList)
            {
                string[] split = item.Split(',');
                if (string.IsNullOrWhiteSpace(split[1]))
                {
                    this.treeView1.Nodes.Add(split[0]);
                }
                else
                {
                    TreeNode tn = new TreeNode(split[0]);
                    tn.Tag = split[1];
                    this.treeView1.Nodes[this.treeView1.Nodes.Count - 1].Nodes.Add(tn);
                }
            }

        }


        private void GotoWebUrl(string url, WebAfter after)
        {
            wAfter = after;
            webBrowser.Navigate(url);
        }

        private void WebLogin()
        {
            foreach (HtmlElement em in webBrowser.Document.All) //轮循 
            {
                string str = em.Id;
                if (string.IsNullOrWhiteSpace(str))
                {
                    str = em.Name;
                }
                // if ((str == "usrcde") || str == "passwd" || str == "sublogin") //减少处理 
                if ((str == "usrcde") || str == "passwd") //减少处理 
                {
                    switch (str)
                    {
                        case "usrcde":
                            em.SetAttribute("value", "WL0254");//账号，保存在序列化的student类中 
                            break; //填表 
                        case "passwd":
                            em.SetAttribute("value", "123");//密码，保存在序列化的student类中 
                            break; //填表 
                        //case "sublogin":
                        //    btn = em;
                        //  break;
                        default: break;
                    }
                }
            }
            // bool isLogin = false;
            try
            {
                wAfter = WebAfter.无;
                webBrowser.Document.GetElementById("sublogin").InvokeMember("click");
                //isLogin = true;
                //btn.InvokeMember("click"); //触发submit事件 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode tn = e.Node;

            if ((tn.Tag!=null)&&!string.IsNullOrWhiteSpace(tn.Tag.ToString()))
            {
                GotoWebUrl(tn.Tag.ToString(), WebAfter.无);
            }
        }

        private void 获取二期库位表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GotoWebUrl("http://21.ej-sh.net:9191/ctInquiry.shtml?method:bcdt=&sitloc=%E4%BA%8C%E6%9C%9F&rowsPerPage=1000", WebAfter.获取二期库存列表);
        }

        private void 下载送货清单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GotoWebUrl("http://21.ej-sh.net:9191/pbDsql/exp.shtml?rptcde=R18010066&format=XLS&strdats=2019-04-19&endates=2019-04-19", WebAfter.无);
        }

        private void 郑二毛ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GotoWebUrl(string.Format("http://21.ej-sh.net:9191/dlvFare/sl.shtml?driver={0}&strdats={1}&endates={2}&rowsPerPage=1000"
                ,Uri.EscapeDataString(((ToolStripMenuItem)sender).Text),DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd")
                ,DateTime.Now.ToString("yyyy-MM-dd")), WebAfter.运费管理);
       
        }

        private void 设置入库日期ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSelectDateTime select=new FormSelectDateTime();
            if (select.ShowDialog()==DialogResult.OK)
            {
                webBrowser.Document.GetElementById("edat.ptdate").SetAttribute("Value", 
                    select.monthCalendar1.SelectionStart.ToString("yyyy-MM-dd")+" 22:22:22");
            }
        }

        private void 获取入库单IDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Regex regex1 = new Regex("INPUT class=cbox type=checkbox value=\\d+ name=ids");
            Regex regex2 = new Regex("<TD>RA\\d+</TD>");
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("入库单");
            HtmlElement ele_table = webBrowser.Document.GetElementsByTagName("table")[3];
            foreach (HtmlElement ele in ele_table.GetElementsByTagName("tr"))
            {
                string regexInputString = ele.InnerHtml;
                //File.AppendText(regexInputString + Environment.NewLine);
                if (!string.IsNullOrWhiteSpace(regexInputString) &&
                    regex1.IsMatch(regexInputString) && regex2.IsMatch(regexInputString))
                    {
                        string id = Regex.Match(regex1.Match(regexInputString).Value, "\\d+").Value;
                        string ra = Regex.Match(regex2.Match(regexInputString).Value, "RA\\d+").Value;
                        DataRow dr = dt.NewRow();
                        dr["ID"] = id;
                        dr["入库单"] = ra;
                        dt.Rows.Add(dr);
                    
                }
                
            }
            if (dt.Rows.Count>0)
            {
                FormShowData1 showdata = new FormShowData1(dt);
                if (showdata.ShowDialog()==DialogResult.OK)
                {
                    string url = "http://21.ej-sh.net:9191/ctBcdr/ra.shtml?method:raform=&actype=D&id=" 
                        + showdata.selectRaId;
                    GotoWebUrl(url, WebAfter.无);
                }
            }
            else
            {
                My.ShowErrorMessage("无数据!");
            }
        }

        private void 模拟ToolStripMenuItem_Click(object sender, EventArgs e)
        {
          object obj=  webBrowser.Document.InvokeScript("serial.change");

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            this.contextMenuStrip1.Items.Clear();
            //获取所有的按钮
            foreach (HtmlElement ele in webBrowser.Document.GetElementsByTagName("input"))
            {
                if ("submitbutton".Contains(ele.GetAttribute("type")))
                {
                    ToolStripItem tsi = this.contextMenuStrip1.Items.Add(ele.GetAttribute("value"));
                    tsi.Tag = ele.Id;
                    tsi.Click += Tsi_Click;
                }
            }
        }

        private void Tsi_Click(object sender, EventArgs e)
        {
            ToolStripItem tsi = sender as ToolStripItem;

            HtmlElement button = webBrowser.Document.GetElementById(tsi.Tag.ToString());
            button.InvokeMember("click");
        }
    }
}
