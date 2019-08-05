﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIPXiaoTong.Model
{

    /// <summary>
    /// 错误代码
    /// </summary>
    public enum ErrorCode
    {
        /// <summary>
        /// 1.编码不能为空
        /// </summary>       
        [Description("编码不能为空")]
        CodeIsNotNull = 1,

        /// <summary>
        /// 2.编码已存在
        /// </summary>
        [Description("编码已存在")]
        CodeIsExists = 2,

        /// <summary>
        /// 3.系统错误
        /// </summary>
        [Description("系统错误")]
        Exception = 3,

        /// <summary>
        /// 4.记录不存在
        /// </summary>
        [Description("记录不存在")]
        RecordNoExists = 4,

        /// <summary>
        /// 5.正在使用，无法删除
        /// </summary> 
        [Description("正在使用，无法删除")]
        InUseNotDelete = 5,

        /// <summary>
        /// 6.名称已存在
        /// </summary>
        [Description("名称已存在")]
        NameIsExists = 6,


        /// <summary>
        /// 7.名称不能为空
        /// </summary>
        [Description("名称不能为空")]
        NameIsNotNull = 7,


        /// <summary>
        /// 8.明细不能为空
        /// </summary>
        [Description("明细不能为空")]
        DetailIsNotNull = 8,


        /// <summary>
        /// 9.用户不存在
        /// </summary>
        [Description("用户不存在")]
        UserNotExists = 9,


        /// <summary>
        /// 10.用户名称错误
        /// </summary>
        [Description("用户名称错误")]
        UserNameError = 10,


        /// <summary>
        /// 11.激活码错误
        /// </summary>
        [Description("激活码错误")]
        ActiveCodeError = 11,

        /// <summary>
        /// 12.激活码不能为空
        /// </summary>
        [Description("激活码不能为空")]
        ActiveCodeIsNotNull = 12,

        /// <summary>
        /// 13.微信ID不能为空
        /// </summary>
        [Description("微信ID不能为空")]
        WXIDIsNotNull = 13,

        /// <summary>
        /// 14.微信ID不能为空
        /// </summary>
        [Description("微信ID不存在")]
        WXIDNotExists = 14,

        /// <summary>
        /// 15.密码不正确
        /// </summary>
        [Description("密码不正确")]
        PasswordError = 15,

        /// <summary>
        /// 16.密码不能为空
        /// </summary>
        [Description("密码不能为空")]
        PasswordNotNull = 16,

    }



    public enum UserStatus
    {

        /// <summary>
        /// 锁定
        /// </summary>
        [Description("锁定")]
        Lock = -2,

        /// <summary>
        /// 停用
        /// </summary>
        [Description("停用")]
        Disable = -1,

        /// <summary>
        /// 用户未激活（默认值）
        /// </summary>
        [Description("未激活")]
        NotActive = 0,

        /// <summary>
        /// 启用
        /// </summary>
        [Description("启用")]
        Enable = 1,
    }

    public enum HouseTypeShowStatus
    {
        /// <summary>
        /// 未通过
        /// </summary>
        [Description("未通过")]
        NotPass = -1,


        /// <summary>
        /// 已提交，待审核（默认状态）
        /// </summary>
        [Description("待审核")]
        AlreadySubmit = 0,

        /// <summary>
        /// 审核通过
        /// </summary>
        [Description("审核通过")]
        Pass = 1,
    }

    public enum EmployeeStatus
    {

        /// <summary>
        /// 锁定
        /// </summary>
        [Description("锁定")]
        Lock = -2,

        /// <summary>
        /// 停用
        /// </summary>
        [Description("停用")]
        Disable = -1,

        /// <summary>
        /// 用户未激活（默认值）
        /// </summary>
        [Description("未激活")]
        NotActive = 0,

        /// <summary>
        /// 启用
        /// </summary>
        [Description("启用")]
        Enable = 1,
    }


    public enum LoginStatus
    {
        /// <summary>
        /// 未知错误
        /// </summary>
        [Description("未知错误")]
        Unknown = -9999,

        /// <summary>
        /// 商家不存在
        /// </summary>
        [Description("商家不存在")]
        MerchantNotExists = -5,

        /// <summary>
        /// 用户不存在
        /// </summary>
        [Description("用户不存在")]
        NotExists = -4,

        /// <summary>
        /// 密码不正确
        /// </summary>
        [Description("密码不正确")]
        PasswordError = -3,

        /// <summary>
        /// 用户已锁定
        /// </summary>
        [Description("用户已锁定")]
        Lock = -2,

        /// <summary>
        /// 用户已停用
        /// </summary>
        [Description("用户已停用")]
        Disable = -1,

        /// <summary>
        /// 用户未激活（默认值）
        /// </summary>
        [Description("用户未激活")]
        NotActive = 0,

        /// <summary>
        /// 成功
        /// </summary>
        [Description("成功")]
        Success = 1,
    }

    public enum CacheKey
    {
        /// <summary>
        /// 地区
        /// </summary>
        Area = 0,

        /// <summary>
        /// 控制台 菜单
        /// </summary>
        Menu = 2,

        /// <summary>
        /// 控制台 菜单操作
        /// </summary>
        MenuAction = 3,

    }


    /// <summary>
    /// 操作代码
    /// </summary>
    public enum ActionCode
    {
        /// <summary>
        /// 新增
        /// </summary>
        [Description("新增")]
        Add,

        /// <summary>
        /// 修改
        /// </summary>
        [Description("修改")]
        Modify,

        /// <summary>
        /// 删除
        /// </summary>
        [Description("删除")]
        Delete,

        /// <summary>
        /// 导出
        /// </summary>
        [Description("导出")]
        Export,

        /// <summary>
        /// 查看列表
        /// </summary>
        [Description("查看")]
        Index,


        /// <summary>
        /// 审核
        /// </summary>
        [Description("审核")]
        Audit,

        /// <summary>
        /// 审核重置
        /// </summary>
        [Description("审核重置")]
        AuditReset,


        /// <summary>
        /// 导入
        /// </summary>
        [Description("导入")]
        Import,

        /// <summary>
        /// 查看详情
        /// </summary>
        [Description("查看详情")]
        Details,

        /// <summary>
        /// 未通过
        /// </summary>
        [Description("未通过")]
        NotPass,

        /// <summary>
        /// 充值
        /// </summary>
        [Description("充值")]
        Recharge,

        /// <summary>
        /// 提现
        /// </summary>
        [Description("提现")]
        Withdraw,

        /// <summary>
        /// 实名认证
        /// </summary>
        [Description("实名认证")]
        RealName,

        /// <summary>
        /// 绑定银行卡
        /// </summary>
        [Description("绑定银行卡")]
        BindCard,

        /// <summary>
        /// 绑定手机
        /// </summary>
        [Description("绑定手机")]
        BindMobile,

        /// <summary>
        /// 订单收款
        /// </summary>
        [Description("订单收款")]
        OrderReceive,

        /// <summary>
        ///订单付款
        /// </summary>
        [Description("订单付款")]
        OrderPay,

        /// <summary>
        ///订单退款
        /// </summary>
        [Description("订单退款")]
        OrderRefund,


        /// <summary>
        /// 浏览
        /// </summary>
        [Description("浏览")]
        View,

        /// <summary>
        /// 电子签约
        /// </summary>
        [Description("电子签约")]
        Contract,

        /// <summary>
        /// 取消
        /// </summary>
        [Description("取消")]
        Cancel,

        /// <summary>
        /// 修改合同号
        /// </summary>
        [Description("修改合同号")]
        ModifyContractNumber,

        /// <summary>
        /// 查询余额（光大）
        /// </summary>
        [Description("查询余额（光大）")]
        QueryGuangDaBalance,

        /// <summary>
        /// 信息补充
        /// </summary>
        [Description("信息补充")]
        AddDetail,
    }

    public enum EmployeeStatusOption
    {
        /// <summary>
        /// 锁定
        /// </summary>
        [Description("锁定")]
        Lock = -2,

        /// <summary>
        /// 停用
        /// </summary>
        [Description("停用")]
        Disable = -1,

        /// <summary>
        /// 用户未激活（默认值）
        /// </summary>
        [Description("未激活")]
        NotActive = 0,

        /// <summary>
        /// 启用
        /// </summary>
        [Description("启用")]
        Enable = 1,
    }

    public enum ProjectStatus
    {

        /// <summary>
        /// 未通过
        /// </summary>
        [Description("未通过")]
        NotPass = -1,


        /// <summary>
        /// 已提交，待审核（默认状态）
        /// </summary>
        [Description("待审核")]
        AlreadySubmit = 0,

        /// <summary>
        /// 审核通过
        /// </summary>
        [Description("审核通过")]
        Pass = 1,
    }

    public enum OrderPaidRechargeStatusOption
    {
        /// <summary>
        /// 失败
        /// </summary>
        [Description("失败")]
        Fail = -1,

        /// <summary>
        /// 未付款
        /// </summary>
        [Description("未付款")]
        Default = 0,

        /// <summary>
        /// 付款中
        /// </summary>
        [Description("付款中")]
        Wait = 1,

        /// <summary>
        /// 已付款
        /// </summary>
        [Description("已付款")]
        Success = 2,
    }

    public enum PingAnOrderPaidRechargeStatusOption
    {
        /// <summary>
        /// 代付失败
        /// </summary>
        [Description("代付失败")]
        SingleOntimePayFailed = -1,

        /// <summary>
        /// 未代付
        /// </summary>
        [Description("未代付")]
        Default = 0,

        /// <summary>
        /// 代付中
        /// </summary>
        [Description("代付中")]
        SingleOntimePayWait = 1,

        /// <summary>
        /// 代付成功
        /// </summary>
        [Description("代付成功")]
        SingleOntimePaySuccess = 2,
    }

    public enum OrderPaidFreezeStatusOption
    {
        /// <summary>
        /// 失败
        /// </summary>
        [Description("失败")]
        Fail = -1,

        /// <summary>
        /// 未冻结
        /// </summary>
        [Description("未冻结")]
        Default = 0,

        /// <summary>
        /// 冻结中
        /// </summary>
        [Description("冻结中")]
        Wait = 1,

        /// <summary>
        /// 已冻结
        /// </summary>
        [Description("已冻结")]
        Success = 2,
    }

    public enum OrderPaidUnFreezeStatusOption
    {
        /// <summary>
        /// 失败
        /// </summary>
        [Description("失败")]
        Fail = -1,

        /// <summary>
        /// 未解冻
        /// </summary>
        [Description("未解冻")]
        Default = 0,

        /// <summary>
        /// 解冻中
        /// </summary>
        [Description("解冻中")]
        Wait = 1,

        /// <summary>
        /// 已解冻
        /// </summary>
        [Description("已解冻")]
        Success = 2,
    }

    public enum PingAnOrderPaidUnFreezeStatusOption
    {
        /// <summary>
        /// 失败
        /// </summary>
        [Description("失败")]
        Fail = -1,

        /// <summary>
        /// 未解止付
        /// </summary>
        [Description("未止付")]
        Default = 0,

        /// <summary>
        /// 解止付中
        /// </summary>
        [Description("止付中")]
        Wait = 1,

        /// <summary>
        /// 已解止付
        /// </summary>
        [Description("已解冻")]
        Success = 2,
    }

    public enum OrderPaidWithdrawStatusOption
    {
        /// <summary>
        /// 失败
        /// </summary>
        [Description("失败")]
        Fail = -1,

        /// <summary>
        /// 未提现
        /// </summary>
        [Description("未提现")]
        Default = 0,

        /// <summary>
        /// 提现中
        /// </summary>
        [Description("提现中")]
        Wait = 1,

        /// <summary>
        /// 已提现
        /// </summary>
        [Description("已提现")]
        Success = 2,
    }

    public enum OrderPaidStatusOption
    {
        /// <summary>
        /// 已撤销
        /// </summary>
        [Description("已撤销")]
        Repeal = -2,

        /// <summary>
        /// 取消
        /// </summary>
        [Description("取消")]
        Cancel = -1,

        /// <summary>
        /// 未支付
        /// </summary>
        [Description("未支付")]
        Default = 0,

        /// <summary>
        /// 付款中
        /// </summary>
        [Description("付款中")]
        PayWait = 1,

        /// <summary>
        /// 已付款
        /// </summary>
        [Description("已付款")]
        PaySuccess = 2,

        /// <summary>
        /// 冻结中
        /// </summary>
        [Description("冻结中")]
        FrozenWait = 3,

        /// <summary>
        /// 已冻结
        /// </summary>
        [Description("已冻结")]
        FrozenSuccess = 4,

        /// <summary>
        /// 解冻中
        /// </summary>
        [Description("解冻中")]
        UnFrozenWait = 5,

        /// <summary>
        /// 已解冻
        /// </summary>
        [Description("已解冻")]
        UnFrozenSuccess = 6,

        /// <summary>
        /// 提现中
        /// </summary>
        [Description("提现中")]
        WithdrawWait = 7,

        /// <summary>
        /// 已提现
        /// </summary>
        [Description("已提现")]
        WithdrawSuccess = 8,

        /// <summary>
        /// 充值中
        /// </summary>
        [Description("充值中")]
        RechargeWait = 9,

        /// <summary>
        /// 已充值
        /// </summary>
        [Description("已充值")]
        RechargeSuccess = 10,

        /// <summary>
        /// 转账中
        /// </summary>
        [Description("代付中")]
        SingleOntimePayWait = 11,

        /// <summary>
        /// 转账成功
        /// </summary>
        [Description("代付成功")]
        SingleOntimePaySuccess = 12,

        /// <summary>
        /// 转账失败
        /// </summary>
        [Description("转账失败")]
        SingleOntimePayFail = 13,

    }

    public enum PingAnOrderPaidStatusOption
    {
        /// <summary>
        /// 预止付
        /// </summary>
        [Description("预止付")]
        Default = 1,

        /// <summary>
        /// 已撤销
        /// </summary>
        [Description("已撤销")]
        Repeal = 2,

        /// <summary>
        /// 已止付
        /// </summary>
        [Description("已止付")]
        FrozenSuccess = 3,

        /// <summary>
        /// 已解止付
        /// </summary>
        [Description("已解止付")]
        UnFrozenSuccess = 4,

        /// <summary>
        /// 已过期
        /// </summary>
        [Description("已过期")]
        OutOfDate = 4,

    }

    public enum EquipmentStatus
    {
        /// <summary>
        /// 锁定
        /// </summary>
        [Description("锁定")]
        Lock = -2,

        /// <summary>
        /// 停用
        /// </summary>
        [Description("停用")]
        Disable = -1,

        /// <summary>
        /// 用户未激活（默认值）
        /// </summary>
        [Description("未激活")]
        NotActive = 0,

        /// <summary>
        /// 启用
        /// </summary>
        [Description("启用")]
        Enable = 1,
    }


    public enum AccountStatus
    {
        /// <summary>
        /// 未开户
        /// </summary>
        [Description("未开户")]
        NotCreate = 0,

        /// <summary>
        /// 已开户
        /// </summary>
        [Description("已开户")]
        Created = 1,

        /// <summary>
        /// 开户完成（已上传身份证）
        /// </summary>
        [Description("开户完成")]
        IDCardUpload = 2,
    }

    public enum BankCardStatus
    {
        /// <summary>
        /// 未校验
        /// </summary>
        [Description("未校验")]
        NotVerify = 0,

        /// <summary>
        /// 已校验
        /// </summary>
        [Description("已校验")]
        IsVerified = 1,
    }

    public enum MemberBalanceHistoryTypeOption
    {
        /// <summary>
        /// 默认状态
        /// </summary>
        [Description("默认状态")]
        Default = 0,

        /// <summary>
        /// 充值
        /// </summary>
        [Description("充值")]
        Recharge = 1,

        /// <summary>
        /// 冻结
        /// </summary>
        [Description("冻结")]
        Freeze = 2,

        /// <summary>
        /// 解冻
        /// </summary>
        [Description("解冻")]
        UnFreeze = 3,

        /// <summary>
        /// 提现
        /// </summary>
        [Description("提现")]
        Withdraw = 4,
    }

    public enum OrderPaidPayActionOption
    {
        /// <summary>
        /// 撤销
        /// </summary>
        [Description("撤销")]
        Repeal = -1,

        /// <summary>
        /// 默认
        /// </summary>
        [Description("")]
        Default = 0,

        /// <summary>
        /// 支付
        /// </summary>
        [Description("支付")]
        Pay = 1,

        /// <summary>
        /// 提现
        /// </summary>
        [Description("提现")]
        Withdraw = 2
    }


    public enum AccountBankOption
    {
        /// <summary>
        /// 默认状态
        /// </summary>
        [Description("")]
        Default = 0,

        /// <summary>
        /// 光大银行
        /// </summary>
        [Description("光大银行")]
        GuangDa = 1,

        /// <summary>
        /// 平安银行
        /// </summary>
        [Description("平安银行")]
        PingAn = 2,
    }

    public enum ProjectGuaranteeMonthOption
    {
        /// <summary>
        /// 1个月
        /// </summary>
        [Description("1个月")]
        OneMonth = 1,

        /// <summary>
        /// 2个月
        /// </summary>
        [Description("2个月")]
        TwoMonth = 2,

        /// <summary>
        /// 3个月
        /// </summary>
        [Description("3个月")]
        ThreeMonth = 3,

        /// <summary>
        /// 4个月
        /// </summary>
        [Description("4个月")]
        FourMonth = 4,

        /// <summary>
        /// 5个月
        /// </summary>
        [Description("5个月")]
        FiveMonth = 5,

        /// <summary>
        /// 6个月
        /// </summary>
        [Description("6个月")]
        SixMonth = 6,
    }

    public enum ProjectGuaranteeAmountOption
    {     
        /// <summary>
        /// 1万元
        /// </summary>
        [Description("1万元")]
        One = 10000,

        /// <summary>
        /// 2万元
        /// </summary>
        [Description("2万元")]
        Two = 20000,

        /// <summary>
        /// 3万元
        /// </summary>
        [Description("3万元")]
        Three = 30000,

        /// <summary>
        /// 4万元
        /// </summary>
        [Description("4万元")]
        Four = 40000,

        /// <summary>
        /// 5万元
        /// </summary>
        [Description("5万元")]
        Five = 50000,

        /// <summary>
        /// 6万元
        /// </summary>
        [Description("6万元")]
        Six = 60000,

        /// <summary>
        /// 7万元
        /// </summary>
        [Description("7万元")]
        Seven = 70000,

        /// <summary>
        /// 8万元
        /// </summary>
        [Description("8万元")]
        Eight = 80000,

        /// <summary>
        /// 9万元
        /// </summary>
        [Description("9万元")]
        Nine = 90000,

        /// <summary>
        /// 10万元
        /// </summary>
        [Description("10万元")]
        Ten = 100000,

        /// <summary>
        /// 11万元
        /// </summary>
        [Description("11万元")]
        Eleven = 110000,

        /// <summary>
        /// 12万元
        /// </summary>
        [Description("12万元")]
        Twelve = 120000,

        /// <summary>
        /// 13万元
        /// </summary>
        [Description("13万元")]
        Thirteen = 130000,

        /// <summary>
        /// 14万元
        /// </summary>
        [Description("14万元")]
        Fourteen = 140000,

        /// <summary>
        /// 15万元
        /// </summary>
        [Description("15万元")]
        Fifteen = 150000,

        /// <summary>
        /// 16万元
        /// </summary>
        [Description("16万元")]
        Sixteen = 160000,

        /// <summary>
        /// 17万元
        /// </summary>
        [Description("17万元")]
        Seventeen = 170000,

        /// <summary>
        /// 18万元
        /// </summary>
        [Description("18万元")]
        Eighteen = 180000,

        /// <summary>
        /// 19万元
        /// </summary>
        [Description("19万元")]
        Nineteen = 190000,

        /// <summary>
        /// 20万元
        /// </summary>
        [Description("20万元")]
        Twenty = 200000,

        /// <summary>
        /// 25万元
        /// </summary>
        [Description("25万元")]
        TwentyFive = 250000,

        /// <summary>
        /// 30万元
        /// </summary>
        [Description("30万元")]
        Thirty = 300000,

        /// <summary>
        /// 35万元
        /// </summary>
        [Description("35万元")]
        Thirtyfive = 350000,

        /// <summary>
        /// 40万元
        /// </summary>
        [Description("40万元")]
        Fourty = 400000,

        /// <summary>
        /// 45万元
        /// </summary>
        [Description("45万元")]
        Fourtyfive = 450000,

        /// <summary>
        /// 50万元
        /// </summary>
        [Description("50万元")]
        Fifty = 500000,

        /// <summary>
        /// 60万元
        /// </summary>
        [Description("60万元")]
         Sixty= 600000,

        /// <summary>
        /// 70万元
        /// </summary>
        [Description("70万元")]
         Seventy= 700000,

        /// <summary>
        /// 80万元
        /// </summary>
        [Description("80万元")]
        Eighty = 800000,

        /// <summary>
        /// 90万元
        /// </summary>
        [Description("90万元")]
         Ninety= 900000,

        /// <summary>
        /// 100万元
        /// </summary>
        [Description("100万元")]
        OneHundred = 1000000,

        /// <summary>
        /// 110万元
        /// </summary>
        [Description("110万元")]
        OneHundredAndTen= 1100000,

        /// <summary>
        /// 120万元
        /// </summary>
        [Description("120万元")]
        OneHundredAndTwenty= 1200000,

        /// <summary>
        /// 130万元
        /// </summary>
        [Description("130万元")]
        OneHundredAndThiry= 1300000,

        /// <summary>
        /// 140万元
        /// </summary>
        [Description("140万元")]
        OneHundredAndFourty= 1400000,

        /// <summary>
        /// 150万元
        /// </summary>
        [Description("150万元")]
        OneHundredAndFifty= 1500000,

        /// <summary>
        /// 160万元
        /// </summary>
        [Description("160万元")]
        OneHundredAndSixty= 1600000,

        /// <summary>
        /// 170万元
        /// </summary>
        [Description("170万元")]
        OneHundredAndSeventy= 1700000,

        /// <summary>
        /// 180万元
        /// </summary>
        [Description("180万元")]
        OneHundredAndEighty= 1800000,

        /// <summary>
        /// 190万元
        /// </summary>
        [Description("190万元")]
        OneHundredAndNinety = 1900000,

        /// <summary>
        /// 200万元
        /// </summary>
        [Description("200万元")]
        TwoHundred = 2000000,

        /// <summary>
        /// 250万元
        /// </summary>
        [Description("250万元")]
        TwoHundredAndFifty= 2500000,

        /// <summary>
        /// 300万元
        /// </summary>
        [Description("300万元")]
        ThreeHundred = 3000000,       
    }

}
