﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace 工作数据分析.Properties {
    using System;
    
    
    /// <summary>
    ///   一个强类型的资源类，用于查找本地化的字符串等。
    /// </summary>
    // 此类是由 StronglyTypedResourceBuilder
    // 类通过类似于 ResGen 或 Visual Studio 的工具自动生成的。
    // 若要添加或移除成员，请编辑 .ResX 文件，然后重新运行 ResGen
    // (以 /str 作为命令选项)，或重新生成 VS 项目。
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   返回此类使用的缓存的 ResourceManager 实例。
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("工作数据分析.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   重写当前线程的 CurrentUICulture 属性，对
        ///   使用此强类型资源类的所有资源查找执行重写。
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   查找类似 SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED
        ///
        ///select v1.Fdate AS &apos;日期&apos;
        ///	,case 
        ///		when v1.FCheckerID &gt; 0
        ///			then &apos;Y&apos;
        ///		when v1.FCheckerID &lt; 0
        ///			then &apos;Y&apos;
        ///		else &apos;&apos;
        ///		end AS &apos;审核&apos;
        ///	
        ///	,v1.FBillNo AS &apos;单据编号&apos;
        ///	,t4.FName AS &apos;供应商&apos;
        ///	,t7.FName AS &apos;收料仓库&apos;
        ///	,t13.FNumber AS &apos;物料长代码&apos;
        ///	,t13.Fname AS &apos;物料名称&apos;
        ///	,t13.Fmodel AS&apos;规格型号&apos;
        ///	,(
        ///		CASE t101.FName
        ///			WHEN &apos;*&apos;
        ///				THEN &apos;&apos;
        ///			ELSE t101.FName
        ///			END
        ///		) AS &apos;辅助属性&apos;
        ///	,u1.FBatchNo&apos;批号&apos;
        ///	,t30.FName AS &apos;基本单位&apos;
        ///	,u1.Fauxqty AS &apos;实收数量&apos;
        ///	,t552.FName AS &apos;辅助单位 [字符串的其余部分被截断]&quot;; 的本地化字符串。
        /// </summary>
        internal static string 二期仓库入库 {
            get {
                return ResourceManager.GetString("二期仓库入库", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Set Nocount on
        ///
        ///Create Table #TempInventory (
        ///	[FBrNo] [varchar](10) NOT NULL
        ///	,[FItemID] [int] NOT NULL
        ///	,[FBatchNo] [varchar](200) NOT NULL
        ///	,[FMTONo] [varchar](200) NOT NULL
        ///	,[FSupplyID] [int] NOT NULL
        ///	,[FStockID] [int] NOT NULL
        ///	,[FQty] [decimal](28, 10) NOT NULL
        ///	,[FBal] [decimal](20, 2) NOT NULL
        ///	,[FStockPlaceID] [int] NULL
        ///	,[FKFPeriod] [int] NOT NULL Default(0)
        ///	,[FKFDate] [varchar](255) NOT NULL
        ///	,[FMyKFDate] [varchar](255)
        ///	,[FStockTypeID] [Int] NOT NULL
        ///	,[FQtyLock] [decimal](28 [字符串的其余部分被截断]&quot;; 的本地化字符串。
        /// </summary>
        internal static string 二期原纸仓库即时库存 {
            get {
                return ResourceManager.GetString("二期原纸仓库即时库存", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 select llfx.*
        ///,case when llfx.金额 !=0 then llfx.金额 
        ///when llfx.估算单价!=0 then llfx.估算单价*llfx.实发数量
        ///else 0 end  as &apos;估算金额&apos;
        ///
        ///	from	
        ///	(
        ///	SELECT v1.Fdate as &apos;日期&apos;
        ///	,case 
        ///		when v1.FCheckerID &gt; 0
        ///			then &apos;Y&apos;
        ///		when v1.FCheckerID &lt; 0
        ///			then &apos;Y&apos;
        ///		else &apos;&apos;
        ///		end as &apos;审核&apos;
        ///	,v1.FBillNo as &apos;单据编号&apos;
        ///	,vw.FNumber &apos;物料长代码&apos;
        ///	,vw.FItemID &apos;物料名称&apos;
        ///	,t13.Fmodel AS &apos;规格型号&apos;
        ///	,(
        ///		CASE t34.FName
        ///			WHEN &apos;*&apos;
        ///				THEN &apos;&apos;
        ///			ELSE t34.FName
        ///			END
        ///		) AS &apos;辅助属性&apos;
        ///	,u1.FBatchNo AS &apos;批号&apos;
        ///	,t23.Fname &apos;基本单位&apos;
        ///	,vw.Fauxqty &apos; [字符串的其余部分被截断]&quot;; 的本地化字符串。
        /// </summary>
        internal static string 二期原纸辅料领料明细 {
            get {
                return ResourceManager.GetString("二期原纸辅料领料明细", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 select * from (
        ///SELECT *
        ///FROM `slbz`.`订单_生产单`
        ///WHERE  `slbz`.`订单_生产单`.完工=0 AND `slbz`.`订单_生产单`.入库=0 and `slbz`.`订单_生产单`.所属=&apos;二期&apos;
        ///)a
        ///where ((SELECT sum(入库数量) from slbz.成品_入库明细 where slbz.成品_入库明细.生产单号=a.生产单号)&lt;a.`订单`) 的本地化字符串。
        /// </summary>
        internal static string 二期未完工订单 {
            get {
                return ResourceManager.GetString("二期未完工订单", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Set Nocount on
        ///Create Table #TempInventory( 
        ///                            [FBrNo] [varchar] (10)  NOT NULL ,
        ///                            [FItemID] [int] NOT NULL ,
        ///                            [FBatchNo] [varchar] (200)  NOT NULL ,
        ///                            [FMTONo] [varchar] (200)  NOT NULL ,
        ///                            [FSupplyID] [int] NOT NULL ,
        ///                            [FStockID] [int] NOT NULL ,
        ///                            [FQty] [decimal](28, 10) NOT NULL ,
        ///                            [FB [字符串的其余部分被截断]&quot;; 的本地化字符串。
        /// </summary>
        internal static string 二期胶印纸箱仓库即时库存 {
            get {
                return ResourceManager.GetString("二期胶印纸箱仓库即时库存", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Set Nocount on
        ///Create Table #TempInventory( 
        ///                            [FBrNo] [varchar] (10)  NOT NULL ,
        ///                            [FItemID] [int] NOT NULL ,
        ///                            [FBatchNo] [varchar] (200)  NOT NULL ,
        ///                            [FMTONo] [varchar] (200)  NOT NULL ,
        ///                            [FSupplyID] [int] NOT NULL ,
        ///                            [FStockID] [int] NOT NULL ,
        ///                            [FQty] [decimal](28, 10) NOT NULL ,
        ///                            [FB [字符串的其余部分被截断]&quot;; 的本地化字符串。
        /// </summary>
        internal static string 二期辅料仓库即时库存 {
            get {
                return ResourceManager.GetString("二期辅料仓库即时库存", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 select      &apos; &apos; as 入库类型,
        ///to_char(t.ptdate, &apos;yyyy-mm-dd hh24:mi:ss&apos;) as 入库时间,
        ///       t.pono as 入库单号,
        ///       t.serial as 生产单号,       
        ///       t.ordnum as 订单数,
        ///       t.accnuml as 入库数,
        ///       (select x.smpnme
        ///          from v_ord x
        ///         where x.orgcde = t.orgcde
        ///           and x.serial = t.serial)||&apos; &apos;||t.prdnme as 产品名称,      
        ///       t.prices*t.accnuml as 金额,
        ///       case t.objtyp
        ///         when &apos;CB&apos; then
        ///       round(round((select c.psizel from v_ord c where c.orgcde = t.orgcde and c.serial = t. [字符串的其余部分被截断]&quot;; 的本地化字符串。
        /// </summary>
        internal static string 入库查询 {
            get {
                return ResourceManager.GetString("入库查询", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 SELECT
        ///[orderno]&apos;工单号&apos;
        ///	,[custname]&apos;客户名&apos;
        ///	,[paper]&apos;材质&apos;
        ///	,[prodwid]&apos;门幅&apos;
        ///	,[wid]&apos;宽度&apos;
        ///	,[lenmm]&apos;长度&apos;
        ///	,[ordnum]&apos;数量&apos;
        ///	,[cutdata1]&apos;压线&apos;
        ///	,[lb]&apos;楞型&apos;
        ///	,[mem]&apos;备注&apos;
        ///	,CONVERT(CHAR,[begindate],120)&apos;开始时间&apos;
        ///	,CONVERT(CHAR,[finishdate],120)&apos;结束时间&apos;
        ///	,[prodtime]&apos;生产时间&apos;
        ///	,[瓦片线]=&apos;1.8米制版线&apos;
        ///FROM [dbo].[finish]
        ///WHERE [finishdate] BETWEEN CONVERT(DATETIME,dateadd(dd,-30,GETDATE())) and CONVERT(DATETIME,GETDATE()) 的本地化字符串。
        /// </summary>
        internal static string 制版线完工_1800 {
            get {
                return ResourceManager.GetString("制版线完工_1800", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 SELECT  [orderno]&apos;工单号&apos;
        ///	,[custname]&apos;客户名&apos;
        ///	,[paper]&apos;材质&apos;
        ///	,[prodwid]&apos;门幅&apos;
        ///	,[wid]&apos;宽度&apos;
        ///	,[lenmm]&apos;长度&apos;
        ///	,[ordnum]&apos;数量&apos;
        ///	,[cutdata1]&apos;压线&apos;
        ///	,[lb]&apos;楞型&apos;
        ///	,[mem]&apos;备注&apos;
        ///	,CONVERT(CHAR,[begindate],120)&apos;开始时间&apos;
        ///	,CONVERT(CHAR,[finishdate],120)&apos;结束时间&apos;
        ///	,[prodtime]&apos;生产时间&apos;
        ///	,[瓦片线]=&apos;2.2米制版线&apos;
        ///FROM [dbo].[finish]
        ///WHERE [finishdate] BETWEEN CONVERT(DATETIME,dateadd(dd,-30,GETDATE())) and CONVERT(DATETIME,GETDATE()) 的本地化字符串。
        /// </summary>
        internal static string 制版线完工_2200 {
            get {
                return ResourceManager.GetString("制版线完工_2200", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 select 
        ///DP.[Name] as GroupName,
        ///Item.Cust_OrderID,
        ///Cust.[Name] as CustomName,
        ///ORD.WEB,
        ///F.[Name] as Flute,
        ///Mass.fid as Mass,
        ///Item.Sec as sec,
        ///Item.Length as Length,
        ///case when Item.sec=0 then 0 else
        ///cast(item.width/item.sec as int) end as secwidth,
        ///Item.Lines as Lines,
        ///min(ComOrd.StartTime) as StartTime,
        ///max(ComOrd.EndTime) as EndTime,
        ///CONVERT(VARCHAR(11),dateadd(ss,datediff(ss,min(ComOrd.StartTime),max(ComOrd.EndTime)),&apos;00:00:00&apos;),108) as ProdTime,
        ///sum(ComOrd.StopTimes) as StopTimes,--停车次数
        ///su [字符串的其余部分被截断]&quot;; 的本地化字符串。
        /// </summary>
        internal static string 制版线完工_2500 {
            get {
                return ResourceManager.GetString("制版线完工_2500", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 SELECT
        ///[orderno]&apos;工单号&apos;
        ///	,[custname]&apos;客户名&apos;
        ///	,[paper]&apos;材质&apos;
        ///	,[prodwid]&apos;门幅&apos;
        ///	,[wid]&apos;宽度&apos;
        ///	,[lenmm]&apos;长度&apos;
        ///	,[ordnum]&apos;数量&apos;
        ///	,[lb]&apos;楞型&apos;
        ///	,CONVERT(CHAR,[finishdate],120)&apos;结束时间&apos;
        ///	,[瓦片线]=&apos;1.8米制版线&apos;
        ///FROM [dbo].[finish]
        ///WHERE [finishdate] BETWEEN CONVERT(DATETIME,dateadd(dd,-1,GETDATE())) and CONVERT(DATETIME,GETDATE())  的本地化字符串。
        /// </summary>
        internal static string 制版线完工1800_1天 {
            get {
                return ResourceManager.GetString("制版线完工1800_1天", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 SELECT
        ///[orderno]&apos;工单号&apos;
        ///	,[custname]&apos;客户名&apos;
        ///	,[paper]&apos;材质&apos;
        ///	,[prodwid]&apos;门幅&apos;
        ///	,[wid]&apos;宽度&apos;
        ///	,[lenmm]&apos;长度&apos;
        ///	,[ordnum]&apos;数量&apos;
        ///	,[lb]&apos;楞型&apos;
        ///	,CONVERT(CHAR,[finishdate],120)&apos;结束时间&apos;
        ///	,[瓦片线]=&apos;1.8米制版线F&apos;
        ///FROM [dbo].[finish]
        ///WHERE [finishdate] BETWEEN CONVERT(DATETIME,dateadd(dd,-1,GETDATE())) and CONVERT(DATETIME,GETDATE()) 的本地化字符串。
        /// </summary>
        internal static string 制版线完工1800F_1天 {
            get {
                return ResourceManager.GetString("制版线完工1800F_1天", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 SELECT
        ///[orderno]&apos;工单号&apos;
        ///	,[custname]&apos;客户名&apos;
        ///	,[paper]&apos;材质&apos;
        ///	,[prodwid]&apos;门幅&apos;
        ///	,[wid]&apos;宽度&apos;
        ///	,[lenmm]&apos;长度&apos;
        ///	,[ordnum]&apos;数量&apos;
        ///	,[cutdata1]&apos;压线&apos;
        ///	,[lb]&apos;楞型&apos;
        ///	,[mem]&apos;备注&apos;
        ///	,CONVERT(CHAR,[begindate],120)&apos;开始时间&apos;
        ///	,CONVERT(CHAR,[finishdate],120)&apos;结束时间&apos;
        ///	,[prodtime]&apos;生产时间&apos;
        ///	,[瓦片线]=&apos;1.8米制版线&apos;
        ///FROM [dbo].[finish]
        ///WHERE [finishdate] BETWEEN CONVERT(DATETIME,dateadd(dd,-1,GETDATE())) and CONVERT(DATETIME,GETDATE()) and [orderno] like&apos;C%&apos;  ORDER BY [finishdate]desc 的本地化字符串。
        /// </summary>
        internal static string 制版线完工1800当天 {
            get {
                return ResourceManager.GetString("制版线完工1800当天", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 SELECT
        ///[orderno]&apos;工单号&apos;
        ///	,[custname]&apos;客户名&apos;	
        ///	,[prodwid]&apos;门幅&apos;
        ///	,[lb]&apos;楞型&apos;
        ///	,[paper]&apos;材质&apos;
        ///	,[wid]&apos;宽度&apos;
        ///	,[lenmm]&apos;长度&apos;
        ///	,[ordnum]&apos;数量&apos;
        ///	,CONVERT(CHAR,[finishdate],120)&apos;结束时间&apos;|
        ///,[mem]&apos;备注&apos;
        ///	,[瓦片线]=&apos;1.8米制版线&apos;
        ///FROM [dbo].[finish]
        ///WHERE [finishdate] BETWEEN CONVERT(DATETIME,dateadd(dd,-1,GETDATE())) and CONVERT(DATETIME,GETDATE()) and [orderno] like&apos;C%&apos;  ORDER BY [finishdate]desc 的本地化字符串。
        /// </summary>
        internal static string 制版线完工1800当天1 {
            get {
                return ResourceManager.GetString("制版线完工1800当天1", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 SELECT  [orderno]&apos;工单号&apos;
        ///	,[custname]&apos;客户名&apos;
        ///	,[paper]&apos;材质&apos;
        ///	,[prodwid]&apos;门幅&apos;
        ///	,[wid]&apos;宽度&apos;
        ///	,[lenmm]&apos;长度&apos;
        ///	,[ordnum]&apos;数量&apos;
        ///	,[lb]&apos;楞型&apos;
        ///	,CONVERT(CHAR,[finishdate],120)&apos;结束时间&apos;
        ///	,[瓦片线]=&apos;2.2米制版线&apos;
        ///FROM [dbo].[finish]
        ///WHERE [finishdate] BETWEEN CONVERT(DATETIME,dateadd(dd,-1,GETDATE())) and CONVERT(DATETIME,GETDATE()) 的本地化字符串。
        /// </summary>
        internal static string 制版线完工2200_1天 {
            get {
                return ResourceManager.GetString("制版线完工2200_1天", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 select 
        ///DP.[Name] as GroupName,
        ///Item.Cust_OrderID,
        ///Cust.[Name] as CustomName,
        ///ORD.WEB,
        ///F.[Name] as Flute,
        ///Mass.fid as Mass,
        ///Item.Sec as sec,
        ///Item.Length as Length,
        ///case when Item.sec=0 then 0 else
        ///cast(item.width/item.sec as int) end as secwidth,
        ///Item.Lines as Lines,
        ///min(ComOrd.StartTime) as StartTime,
        ///max(ComOrd.EndTime) as EndTime,
        ///CONVERT(VARCHAR(11),dateadd(ss,datediff(ss,min(ComOrd.StartTime),max(ComOrd.EndTime)),&apos;00:00:00&apos;),108) as ProdTime,
        ///sum(ComOrd.StopTimes) as StopTimes,--停车次数
        ///su [字符串的其余部分被截断]&quot;; 的本地化字符串。
        /// </summary>
        internal static string 制版线完工2500_1天 {
            get {
                return ResourceManager.GetString("制版线完工2500_1天", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 select 
        ///DP.[Name] as GroupName,
        ///Item.Cust_OrderID,
        ///Cust.[Name] as CustomName,
        ///ORD.WEB,
        ///F.[Name] as Flute,
        ///Mass.fid as Mass,
        ///Item.Sec as sec,
        ///Item.Length as Length,
        ///case when Item.sec=0 then 0 else
        ///cast(item.width/item.sec as int) end as secwidth,
        ///Item.Lines as Lines,
        ///min(ComOrd.StartTime) as StartTime,
        ///max(ComOrd.EndTime) as EndTime,
        ///CONVERT(VARCHAR(11),dateadd(ss,datediff(ss,min(ComOrd.StartTime),max(ComOrd.EndTime)),&apos;00:00:00&apos;),108) as ProdTime,
        ///sum(ComOrd.StopTimes) as StopTimes,--停车次数
        ///su [字符串的其余部分被截断]&quot;; 的本地化字符串。
        /// </summary>
        internal static string 制版线完工2500当天 {
            get {
                return ResourceManager.GetString("制版线完工2500当天", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 select 
        ///DP.[Name] as GroupName,
        ///Item.Cust_OrderID,
        ///Cust.[Name] as CustomName,
        ///ORD.WEB,
        ///F.[Name] as Flute,
        ///Mass.fid as Mass,
        ///Item.Sec as sec,
        ///Item.Length as Length,
        ///case when Item.sec=0 then 0 else
        ///cast(item.width/item.sec as int) end as secwidth,
        ///Item.Lines as Lines,
        ///min(ComOrd.StartTime) as StartTime,
        ///max(ComOrd.EndTime) as EndTime,
        ///CONVERT(VARCHAR(11),dateadd(ss,datediff(ss,min(ComOrd.StartTime),max(ComOrd.EndTime)),&apos;00:00:00&apos;),108) as ProdTime,
        ///sum(ComOrd.StopTimes) as StopTimes,--停车次数
        ///su [字符串的其余部分被截断]&quot;; 的本地化字符串。
        /// </summary>
        internal static string 制版线完工2500当天1 {
            get {
                return ResourceManager.GetString("制版线完工2500当天1", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 declare @ProdLineLevelCnt INT,@size INT,@Page int
        ///	SET @ProdLineLevelCnt=2
        ///   set  @size=2000
        ///   set  @Page=1
        ///	
        ///	SET NOCOUNT ON;
        ///    --异常单分压资料
        ///     
        ///    
        ///    create table #OrderItemLines (orderitem_fid varchar(100),
        ///                                  Lines varchar(100))
        ///    create table #TmpM (OrderSN int,
        ///                        fid varchar(100),
        ///                        Length int,
        ///                        Qty int
        ///                        )
        ///   insert into #OrderItemLines exec GetNoNomalLines         /// [字符串的其余部分被截断]&quot;; 的本地化字符串。
        /// </summary>
        internal static string 制版线当前排程2500 {
            get {
                return ResourceManager.GetString("制版线当前排程2500", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 SELECT *
        ///FROM (select t.serial as 工单号
        ///	,(select x.smpnme
        ///	from v_ord x
        ///	where  x.serial = t.serial
        ///	)as 客户简称
        ///	,trim(t.prdnme) as 产品名称
        ///	,min(ptdate)as 最早入库时间
        ///	,min(t.UPDATED) as 最早入库操作时间
        ///	,(
        ///		SELECT min(ta.CREATED)
        ///		FROM V_HR_PIECE_DATA ta
        ///		WHERE ta.serial = t.serial AND ta.PRCTYPNME like&apos;%打包%&apos; 
        ///		) as 最早报工时间
        ///from v_pb_bcdr t
        ///where t.objtyp = &apos;CL&apos;
        ///	and t.orgcde = &apos;KS03&apos;
        ///	AND to_char(t.ptdate, &apos;yyyy-mm-dd&apos;) &gt;= (
        ///		select to_char(sysdate - 10, &apos;yyyy-mm-dd&apos;)
        ///		from dual
        ///		)
        ///	AND to_char( [字符串的其余部分被截断]&quot;; 的本地化字符串。
        /// </summary>
        internal static string 提前入库明细 {
            get {
                return ResourceManager.GetString("提前入库明细", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 SELECT *
        ///FROM (select t.serial as 工单号
        ///	,(select x.smpnme
        ///	from v_ord x
        ///	where  x.serial = t.serial
        ///	)as 客户简称
        ///	,trim(t.prdnme) as 产品名称
        ///	,min(ptdate)as 最早入库时间
        ///	,min(t.UPDATED) as 最早入库操作时间
        ///	,(
        ///		SELECT min(ta.CREATED)
        ///		FROM V_HR_PIECE_DATA ta
        ///		WHERE ta.serial = t.serial AND ta.PRCTYPNME like&apos;%打包%&apos; 
        ///		) as 最早报工时间
        ///from v_pb_bcdr t
        ///where t.objtyp = &apos;CL&apos;
        ///	and t.orgcde = &apos;KS03&apos;
        ///	and to_char(t.UPDATED, &apos;yyyy-mm-dd&apos;)=(
        ///		select to_char(sysdate, &apos;yyyy-mm-dd&apos;)
        ///		from dual)
        ///	AND to_char(t.ptdate, &apos; [字符串的其余部分被截断]&quot;; 的本地化字符串。
        /// </summary>
        internal static string 提前入库明细当天 {
            get {
                return ResourceManager.GetString("提前入库明细当天", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 SELECT to_char(&quot;送货时间&quot;,&apos;yyyy-mm-dd&apos;) 送货日期,&quot;送货单号&quot;,&quot;客户简称&quot;
        ///	,sum(&quot;金额&quot;)金额,&quot;业务员&quot;,&quot;司机&quot;,&quot;排车员&quot;操作人	
        ///FROM &quot;FERP&quot;.&quot;V_DY_PB_BCDX_CT_DETI_RPT&quot;
        ///WHERE &quot;送货日期&quot;&gt;=&apos;@starttime&apos; and &quot;送货日期&quot;&lt;=&apos;@endtime&apos; and
        ///&quot;排车员&quot;in(&apos;肖永卫&apos;,&apos;颜玲敏&apos;,&apos;应燕华&apos;,&apos;刘正利&apos;,&apos;董小浩&apos;,&apos;叶耀红&apos;)
        ///group by &quot;送货时间&quot;,&quot;送货单号&quot;,&quot;客户简称&quot;,&quot;业务员&quot;,&quot;司机&quot;,&quot;排车员&quot;
        ///ORDER BY &quot;送货时间&quot; DESC 的本地化字符串。
        /// </summary>
        internal static string 获取送货单回单信息 {
            get {
                return ResourceManager.GetString("获取送货单回单信息", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 SELECT &quot;ID&quot;
        ///,&quot;PAYSTS&quot;结算
        ///,&quot;PTDATE&quot;打单时间	
        ///	,&quot;DRIVER&quot;司机
        ///		,&quot;PLNCDE&quot;装车单号
        ///	,&quot;PONO&quot;送货单号
        ///	,(select i.smpnme
        ///          from pb_clnt i
        ///         where i.clientid = t.clientid
        ///           and i.orgcde = t.orgcde
        ///           and i.clntcde = t.clntcde) as 客户
        ///           ,(select round(sum(i.ratios * i.acreage * i.accnumr),2)
        ///          from v_pb_bcdx_ct i
        ///         where i.clientid = t.clientid
        ///           and i.orgcde = t.orgcde
        ///           and i.pono = t.pono) as 折算面积
        ///	,&quot;ACCAMT&quot;运费	
        ///	,&quot;ANNAMT2&quot;补运费
        ///	,&quot;ANNAMT&quot;        /// [字符串的其余部分被截断]&quot;; 的本地化字符串。
        /// </summary>
        internal static string 运费结算 {
            get {
                return ResourceManager.GetString("运费结算", resourceCulture);
            }
        }
    }
}
