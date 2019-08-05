using Aliyun.Acs.Core;
using Aliyun.Acs.Core.Profile;
using Aliyun.Acs.Dysmsapi.Model.V20170525;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.Ali
{
   public class AliSms
    {
        public string accessKeyId { get; set; }
        public string accessKeySecret { get; set; }
        public string TemplateCode { get; set; }
        public string SignName { get; set; }

        public AliSms(string accessKeyId, string accessKeySecret, string TemplateCode, string SignName)
        {
            this.accessKeyId = accessKeyId;
            this.accessKeySecret = accessKeySecret;
            this.TemplateCode = TemplateCode;
            this.SignName = SignName;
        }

        public SendSmsResponse Send(string PhoneNumbers, string Code)
        {
            String product = "Dysmsapi";//短信API产品名称（短信产品名固定，无需修改）
            String domain = "dysmsapi.aliyuncs.com";//短信API产品域名（接口地址固定，无需修改）
            String accessKeyId = this.accessKeyId;//你的accessKeyId，参考本文档步骤2
            String accessKeySecret = this.accessKeySecret;//你的accessKeySecret，参考本文档步骤2
            IClientProfile profile = DefaultProfile.GetProfile("cn-hangzhou", accessKeyId, accessKeySecret);

            //IAcsClient client = new DefaultAcsClient(profile);
            // SingleSendSmsRequest request = new SingleSendSmsRequest();
            //初始化ascClient,暂时不支持多region（请勿修改）

            DefaultProfile.AddEndpoint("cn-hangzhou", "cn-hangzhou", product, domain);
            IAcsClient acsClient = new DefaultAcsClient(profile);
            SendSmsRequest request = new SendSmsRequest();


            //必填:待发送手机号。支持以逗号分隔的形式进行批量调用，批量上限为1000个手机号码,批量调用相对于单条调用及时性稍有延迟,验证码类型的短信推荐使用单条调用的方式
            request.PhoneNumbers = PhoneNumbers;

            //必填:短信签名-可在短信控制台中找到
            request.SignName = this.SignName;

            //必填:短信模板-可在短信控制台中找到
            request.TemplateCode = this.TemplateCode;

            //可选:模板中的变量替换JSON串,如模板内容为"亲爱的${name},您的验证码为${code}"时,此处的值为
            request.TemplateParam = "{\"code\":\"" + Code + "\"}";

            //可选:outId为提供给业务方扩展字段,最终在短信回执消息中将此值带回给调用者
            request.OutId = "yourOutId";

            //请求失败这里会抛ClientException异常
            SendSmsResponse sendSmsResponse = acsClient.GetAcsResponse(request);

            return sendSmsResponse;

        }
    }
}
