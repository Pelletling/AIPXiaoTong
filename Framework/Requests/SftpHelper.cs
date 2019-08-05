﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tamir.SharpSsh.jsch;

namespace Framework.Requests
{
    //登录验证信息         
    public class MyUserInfo : UserInfo
    {
        String passwd;

        public String getPassword() { return passwd; }
        public void setPassword(String passwd) { this.passwd = passwd; }

        public String getPassphrase() { return null; }
        public bool promptPassphrase(String message) { return true; }

        public bool promptPassword(String message) { return true; }
        public bool promptYesNo(String message) { return true; }
        public void showMessage(String message) { }

    }
    public class SftpHelper
    {

        private Session m_session;
        private Channel m_channel;
        private ChannelSftp m_sftp;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="ip">sftp地址</param>
        /// <param name="user">sftp用户名</param>
        /// <param name="pwd">sftp密码</param>
        /// <param name="port">端口，默认20</param>
        public SftpHelper(string ip, string user, string pwd, string port = "20")
        {
            int serverport = Int32.Parse(port);

            JSch jsch = new JSch();
            m_session = jsch.getSession(user, ip, serverport);

            MyUserInfo ui = new MyUserInfo();
            ui.setPassword(pwd);
            m_session.setUserInfo(ui);
        }

        /// <summary>
        /// 连接状态
        /// </summary>     
        public bool Connected { get { return m_session.isConnected(); } }

        /// <summary>
        /// 连接SFTP
        /// </summary>     
        public bool Connect()
        {
            try
            {
                if (!Connected)
                {
                    m_session.connect();
                    m_channel = m_session.openChannel("sftp");
                    m_channel.connect();
                    m_sftp = (ChannelSftp)m_channel;
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 断开SFTP 
        /// </summary> 
        public void Disconnect()
        {
            if (Connected)
            {
                m_channel.disconnect();
                m_session.disconnect();
            }
        }

        /// <summary>
        /// SFTP存放文件  
        /// </summary> 
        /// <param name="localPath">本地文件路径</param>
        /// <param name="remotePath">sftp远程地址</param>
        public bool Put(string localPath, string remotePath)
        {
            try
            {
                if (this.Connected)
                {
                    Tamir.SharpSsh.java.String src = new Tamir.SharpSsh.java.String(localPath);
                    Tamir.SharpSsh.java.String dst = new Tamir.SharpSsh.java.String(remotePath);
                    m_sftp.put(src, dst);
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return false;
        }

        /// <summary>
        /// SFTP获取文件  
        /// </summary> 
        /// <param name="remotePath">sftp远程文件地址</param>
        /// <param name="localPath">本地文件存放路径</param>  
        public bool Get(string remotePath, string localPath)
        {
            try
            {
                if (this.Connected)
                {
                    Tamir.SharpSsh.java.String src = new Tamir.SharpSsh.java.String(remotePath);
                    Tamir.SharpSsh.java.String dst = new Tamir.SharpSsh.java.String(localPath);
                    m_sftp.get(src, dst);
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return false;
        }

        /// <summary>
        /// 删除SFTP文件  
        /// </summary> 
        /// <param name="remoteFile">sftp远程文件地址</param>
        public bool Delete(string remoteFile)
        {
            try
            {
                if (this.Connected)
                {
                    m_sftp.rm(remoteFile);
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return false;
        }


        /// <summary>
        /// 移动SFTP文件  
        /// </summary> 
        /// <param name="currentFilename">sftp远程文件地址</param>
        /// <param name="newDirectory">sftp移动至文件地址</param>
        public bool Move(string currentFilename, string newDirectory)
        {
            try
            {
                if (this.Connected)
                {
                    Tamir.SharpSsh.java.String src = new Tamir.SharpSsh.java.String(currentFilename);
                    Tamir.SharpSsh.java.String dst = new Tamir.SharpSsh.java.String(newDirectory);
                    m_sftp.rename(src, dst);
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return false;
        }

        /// <summary>
        /// 获取SFTP文件列表  
        /// </summary> 
        /// <param name="remotePath">sftp远程文件目录</param>
        /// <param name="fileType">文件类型</param>
        public ArrayList GetFileList(string remotePath, string fileType)
        {
            try
            {

                if (this.Connected)
                {
                    Tamir.SharpSsh.java.util.Vector vvv = m_sftp.ls(remotePath);
                    ArrayList objList = new ArrayList();
                    foreach (Tamir.SharpSsh.jsch.ChannelSftp.LsEntry qqq in vvv)
                    {
                        string sss = qqq.getFilename();
                        if (sss.Length > (fileType.Length + 1) && fileType == sss.Substring(sss.Length - fileType.Length))
                        { objList.Add(sss); }
                        else { continue; }
                    }

                    return objList;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }
    }
}
