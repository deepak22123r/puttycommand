using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using Renci.SshNet; /* reference needed: Renci.SshNet.dll */


namespace PuttyCommand
{
    class Program
    {
        
        static void Main(string[] args)
        {

            // Setup Credentials and Server Information
            ConnectionInfo ConnNfo = new ConnectionInfo("192.168.50.183", 22, "finacusmaster",
                new AuthenticationMethod[]{

                // Pasword based Authentication
                new PasswordAuthenticationMethod("finacusmaster","Admin@123")

                // Key Based Authentication (using keys in OpenSSH Format)
                //new PrivateKeyAuthenticationMethod("username",new PrivateKeyFile[]{
                //    new PrivateKeyFile(@"..\openssh.key","passphrase")
               // }),
                }
            );



            //        
            //         // Then you can use a command like this:



            // Execute a(SHELL) Command - prepare upload directory
            //using (var sshclient = new SshClient(ConnNfo))
            //{
            //    sshclient.Connect();
            //    using (var cmd = sshclient.CreateCommand("opensemanticsearch-delete --empty\nThis will delete the whole index, are you sure ? Then enter 'yes' \nyes"))
            //    {
            //        cmd.Execute();
            //        Console.WriteLine("Command>" + cmd.CommandText);
            //        Console.WriteLine("Return Value = {0}", cmd.ExitStatus);
            //    }
            //    sshclient.Disconnect();
            //}

            // Upload A File
            //using (var sftp = new SftpClient(ConnNfo))
            //{
            //    string uploadfn = "Renci.SshNet.dll";

            //    sftp.Connect();
            //    sftp.ChangeDirectory("/tmp/uploadtest");
            //    using (var uplfileStream = System.IO.File.OpenRead(uploadfn))
            //    {
            //        sftp.UploadFile(uplfileStream, uploadfn, true);
            //    }
            //    sftp.Disconnect();
            //}

            // Execute (SHELL) Commands
            using (var sshclient = new SshClient(ConnNfo))
            {
              sshclient.Connect();
                //    ShellStream stream = sshclient.CreateShellStream("opensemanticsearch-delete --empty This will delete the whole index, are you sure ? Then enter ""yes"" ", 80, 24, 800, 600, 1024);
                //    StringBuilder answer;

                //    var reader = new StreamReader(stream);
                //      var writer = new StreamWriter(stream);
                //    writer.AutoFlush = true;
                //    WriteStream("opensemanticsearch-delete --empty", writer, stream);
                //    answer = ReadStream(reader);
                //    Console.WriteLine(answer);
                // quick way to use ist, but not best practice - SshCommand is not Disposed, ExitStatus not checked...
                //   Console.WriteLine(sshclient.CreateCommand("cd /tmp && ls -lah").Execute());
                //   Console.WriteLine(sshclient.CreateCommand("pwd").Execute());
                // Console.WriteLine(sshclient.CreateCommand("ls /home/finacusmaster/Upload").Execute());
                // Console.WriteLine(sshclient.CreateCommand("etl-file /home/finacusmaster/Upload").Execute());
                // Console.WriteLine(sshclient.CreateCommand(" etl-file /home/finacusmaster/Upload/TelegramData/ChatExport_13_11_2019/Result.csv").Execute());
                sshclient.CreateCommand("opensemanticsearch-delete --empty \n ");
                  sshclient.CreateCommand("This will delete the whole index, are you sure ? Then enter \"yes\" \n") ;
                    sshclient.RunCommand("  yes");
                //sshclient.;
                // string answer = sc.;
          //sshclient.CreateCommand("opensemanticsearch-delete --empty \nThis will delete the whole index, are you sure ? Then enter 'yes' \n yes").Execute();
                //Console.WriteLine(sshclient.r);
                
                //Console.WriteLine(sshclient.CreateCommand("yes").Execute());
                // Console.WriteLine(sshclient.CreateCommand("cd /home/finacusmaster").Execute());
                sshclient.Disconnect();
            }
            Console.ReadKey();
        }
       

        public static void WriteStream(string cmd, StreamWriter writer, ShellStream stream)
        {
            writer.WriteLine(cmd);
            while (stream.Length == 0)
            {
                Thread.Sleep(500);
            }
        }

        public static StringBuilder ReadStream(StreamReader reader)
        {
            StringBuilder result = new StringBuilder();

            string line;
            while ((line = reader.ReadLine()) != null)
            {
                result.AppendLine(line);
            }
            return result;
        }
    }
}

































//using System;
//using Tamir.SharpSsh;
//using System.Threading;
//using Renci.SshNet;

//namespace PuttyCommand
//{
//    class Program
//    {
//        public class sharpSshTest
//        {
//            static string host, user, pass;
//            public static void Main()
//            {
//                PrintVersoin();
//                Console.WriteLine();
//                Console.WriteLine("1) Simple SSH session example using SshStream");
//                Console.WriteLine("2) SCP example from local to remote");
//                Console.WriteLine("3) SCP example from remote to local");
//                Console.WriteLine();

//            INPUT:
//                int i = -1;
//                Console.Write("Please enter your choice: ");
//                try
//                {
//                    i = int.Parse(Console.ReadLine());
//                    Console.WriteLine();
//                }
//                catch
//                {
//                    i = -1;
//                }

//                switch (i)
//                {
//                    case 1:
//                        SshStream();
//                        break;
//                    //case 2:
//                    //    Scp("to");
//                    //    break;
//                    //case 3:
//                    //    Scp("from");
//                    //    break;
//                    default:
//                        Console.Write("Bad input, ");
//                        goto INPUT;
//                }
//            }

//            /// <summary>
//            /// Get input from the user
//            /// </summary>
//            public static void GetInput()
//            {
//                host = "192.168.50.183";
//                //Console.Write("User: ");
//                user = "finacusmaster";
//                //Console.Write("Password: ");
//                pass = "Admin@123";
//            }

//            /// <summary>
//            /// Demonstrates the SshStream class
//            /// </summary>
//            public static void SshStream()
//            {
//                GetInput();

//                try
//                {
//                    using (var client = new SshClient(host, user, pass))
//                    {
//                        client.Connect();
//                        try { client.RunCommand("opensemanticsearch-delete --empty");
//                            Console.WriteLine("Working");
//                        }
//                        catch (Exception ex) { }

//                        client.Disconnect();
//                    }

//                    //SshShell ssh; // create our shell

//                    //ssh = new SshShell(host, user, pass);

//                    //// Command Output
//                    //string commandoutput = string.Empty;

//                    //// Remove Terminal Emulation Characters
//                    //ssh.RemoveTerminalEmulationCharacters = true;

//                    //// Connect to the remote server
//                    //ssh.Connect();

//                    //Specify the character that denotes the end of response
//                   // commandoutput = ssh.Expect(promptRegex);
//                    //Console.Write("-Connecting...");
//                    //SshStream ssh = new SshStream(host, user, pass);
//                    //Console.WriteLine("OK ({0}/{1})", ssh.Cipher, ssh.Mac);
//                    //Console.WriteLine("Server version={0}, Client version={1}", ssh.ServerVersion, ssh.ClientVersion);
//                    //Console.WriteLine("-Use the 'exit' command to disconnect.");
//                    //Console.WriteLine();

//                    ////Sets the end of response character
//                    //ssh.Prompt = "#";
//                    ////Remove terminal emulation characters
//                    //ssh.RemoveTerminalEmulationCharacters = true;

//                    ////Reads the initial response from the SSH stream
//                    //Console.Write(ssh.ReadResponse());

//                    ////Send commands from the user
//                    //while (true)
//                    //{
//                    //    string command = Console.ReadLine();
//                    //    if (command.ToLower().Equals("exit"))
//                    //        break;

//                    //    //Write command to the SSH stream
//                    //    ssh.Write(command);
//                    //    //Read response from the SSH stream
//                    //    Console.Write(ssh.ReadResponse());
//                    //}
//                    //ssh.Close(); //Close the connection
//                    //Console.WriteLine("Connection closed.");
//                }
//                catch (Exception e)
//                {
//                    Console.WriteLine(e.Message);
//                }
//            }

//            /// <summary>
//            /// Demonstrates the Scp class
//            /// </summary>
//            /// <param name="cmd">Either "to" or "from"</param>
//            //public static void Scp(string cmd)
//            //{
//            //    GetInput();

//            //    string local = null, remote = null;

//            //    if (cmd.ToLower().Equals("to"))
//            //    {
//            //        Console.Write("Local file: ");
//            //        local = Console.ReadLine();
//            //        Console.Write("Remote file: ");
//            //        remote = Console.ReadLine();
//            //    }
//            //    else if (cmd.ToLower().Equals("from"))
//            //    {
//            //        Console.Write("Remote file: ");
//            //        remote = Console.ReadLine();
//            //        Console.Write("Local file: ");
//            //        local = Console.ReadLine();
//            //    }

//            //    Scp scp = new Scp();
//            //    scp.OnConnecting += new FileTansferEvent(scp_OnConnecting);
//            //    scp.OnStart += new FileTansferEvent(scp_OnProgress);
//            //    scp.OnEnd += new FileTansferEvent(scp_OnEnd);
//            //    scp.OnProgress += new FileTansferEvent(scp_OnProgress);

//            //    try
//            //    {
//            //        if (cmd.ToLower().Equals("to"))
//            //            scp.To(local, host, remote, user, pass);
//            //        else if (cmd.ToLower().Equals("from"))
//            //            scp.From(host, remote, user, pass, local);
//            //    }
//            //    catch (Exception e)
//            //    {
//            //        Console.WriteLine(e.Message);
//            //    }
//            //}

//            static void PrintVersoin()
//            {
//                try
//                {
//                    System.Reflection.Assembly asm
//                        = System.Reflection.Assembly.GetAssembly(typeof(Tamir.SharpSsh.SshStream));
//                    Console.WriteLine("sharpSsh v" + asm.GetName().Version);
//                }
//                catch
//                {
//                    Console.WriteLine("sharpSsh v1.0");
//                }
//            }

//            #region SCP Event Handlers

//            static ConsoleProgressBar progressBar;

//            private static void scp_OnConnecting(int transferredBytes, int totalBytes, string message)
//            {
//                Console.WriteLine();
//                progressBar = new ConsoleProgressBar();
//                progressBar.Update(transferredBytes, totalBytes, message);
//            }

//            private static void scp_OnProgress(int transferredBytes, int totalBytes, string message)
//            {
//                progressBar.Update(transferredBytes, totalBytes, message);
//            }

//            private static void scp_OnEnd(int transferredBytes, int totalBytes, string message)
//            {
//                progressBar.Update(transferredBytes, totalBytes, message);
//                progressBar = null;
//            }

//            #endregion SCP Event Handlers


//        }
//    }
//}
