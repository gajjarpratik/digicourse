<%@ Page Language="C#" AutoEventWireup="true" CodeFile="courseDescription.aspx.cs" Inherits="courseDescription" MasterPageFile="~/MasterPage.master" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
    <title>Dashboard | CourseDescription</title>
</asp:Content>

<asp:Content ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div class="course-description">
    <h1>EC512 - Enterprise Client/Server Software</h1>
    <h3>Reference Materials</h3>
    <ul>
    <li>Numerous online resources, especially the World Wide Web Consortium (w3c.org)
     <li>MSDN Library, Microsoft Developer Network. (http://msdn.microsoft.com or from Visual Studio 2012 help)
    <li>Microsoft Enterprise Learning Library, Microsoft Press. (Free – details will be provided in class).
    <li>Slides and other material provided on the course web site.
    <li>Books of your choice if you need additional resources.
    </ul>
    
    <h3>Prerequisites</h3>

    <p>Students must be fully competent in an object oriented programming language (C++, C#, or Java preferred). Familiarity with web technologies such as HTML, scripting, XML, etc. is helpful. Programming experience with a graphical user environment, MFC, .NET, AWT, X Toolkit, etc. is also very desirable.</p>
    <br />
    <p>Senior or graduate student status is required.</p>
    
    <h3>Course Goals</h3>

    <ul>
    <li>To explore and use cutting edge technology for enterprise software development in the modern distributed environment afforded by the World Wide Web (WWW).</li>
    <li>To understand the implementation of these technologies.                                                       </li>
    <li>Integrate basic knowledge of computer networks with software design.                                          </li>
    <li>Learn modern rapid application development (RAD) techniques.                                                  </li>
    <li>Develop experience in working with current and developing standards, e.g., W3C                                </li>
    <li>Gain an understanding of the issues of interoperability, cross platform migration and backward compatibility. </li>
    </ul>
   
    <h3>Grading</h3>

    <ul>
    <li>30% Attendance                                                         </li>
    <li>40% Programming assignments                                            </li>
    <li>30% Group project  (5 proposal, 10 design presentation, 15 end product)</li>
    </ul>

    <h3>Attendance</h3>
    <p>
    Attendance is an imperative for success in this course. Much of the knowledge is gained through in class examples and discussion. Attendance is required and constitutes 30 percent of your grade. You will receive 1.5 points for every class attended up to the 30 points. There are 27 classes allowing seven extra classes beyond the 20 necessary for a perfect attendance score. You will receive a 0.5 point bonus for every class attended beyond 20. Bonus points apply directly to your average and are not required for achieving a perfect 100 points for the course. They will instead be used to compensate for lost points elsewhere in the course. There will be no excused absences. You are strongly advised to attend all classes to achieve the best possible course grade.
    Late Assignments<br />
    
    Late assignments will be accepted up to one week after the original due date with a 50% penalty. Assignments will not be accepted beyond one week late without extreme mitigating circumstances. Should a situation arise you must contact me in advance and I will decide if an extension is warranted. There is no free late policy in this course.
    Software<br />
    
    The ECE department is a member of the Microsoft DreamSpark program. As a student in this course you will be able to obtain the software and legally install it on your own system for academic and personal use only. You must abide by the special end user license agreement the department has agreed to.
        <br />
     
    You can download the software from ELMS, an online site managed by E-Academy under the DreamSpark program.  If you are on the campus network or a broadband connection you will have adequate bandwidth. Details about accessing DreamSpark via the Internet will be provided in class.
    <h3>Cheating</h3>
    <p>
    Any form of copying of any part of another student’s program is plagiarism and will result in a grade of F. Students may assist one another in understanding the concepts of the course and even to the extent of having somewhat similar program designs. I urge cooperation among students in helping each other with the concepts. The line is drawn at the program code. Program code must be an individual effort. In addition to failing the course I will report all such academic misconduct to the student conduct review board. The easiest way to guarantee you are not crossing the line is to never look at anyone else’s code and do not show your code to anyone else.
    </p><br />
    <h3>Class Decorum</h3>
    <p>
    Please try to be on time. If you arrive late please enter the room discretely and close the door quietly. Reading newspapers or other non-course material during class is distracting to your classmates and extremely discourteous to everyone. Bring a cup of coffee if you can’t keep awake. Return from class break promptly. I have often delayed starting the class after the break waiting for students who are late. This denies your classmates of adequate lecture time. Please have the courtesy to inform me if you are unable to return for some reason.

    <p>
    You may bring and use your notebook computer in class as long as you are using it for legitimate course purposes. Playing games, surfing the web, e-mailing etc. are as discourteous as reading a newspaper. If you see another student doing this you might remind him or her that it can be distracting to others.
    </p>

    <h3>Course Web Site</h3>
    <p>
    This course has a web site. Lab assignments and other material that is relevant to this course will be posted there. The web site will also contain copies of all course overheads. These can be viewed and/or printed as you prefer. The course web site is located at http://digicourse. Visit this site on a regular basis.<br />
    </p>       
    
    <h3>This is a tentative list of topics. Not all topics will necessarily be covered and some not listed may be added. This is not meant to be a week by week listing but is the general order we will cover the topics.</h3>
    
    <ul>
    <li>Downloading and installing tools and resources from DreamSpark and the web.                         </li>
    <li>Review of basic TCP/IP networking                                                                   </li>
    <li>HTML, HTTP, servers and other basic concepts                                                        </li>
    <li>Using Visual Studio 2012 and for HTML authoring                                                     </li>
    <li>Legacy server side technologies, CGI, ISAPI etc.                                                    </li>
    <li>.NET technology overview, ASP.NET.                                                                  </li>
    <li>Important C#  concepts (probably will be left up to you to learn)                                   </li>
    <li>An introduction to the framework class library (brief).                                             </li>
    <li>Web forms using ASP.NET and C#                                                                      </li>
    <li>Scripting on the client, JavaScript and JQuery, debugging script with VS2012                        </li>
    <li>Dynamic HTML (DHTML), HTML5,document object models, styles and other advanced client side techniques</li>
    <li>Web controls and user controls<</li>
    <li>Database access with ADO.NET and Visual Studio tools (including LINQ)</li>
    <li>Use of SQL Server and Microsoft Access                               </li>
    <li>Web applications, session state, dynamic content, etc.               </li>
    <li>AJAX                                                                 </li>
    <li>Encryption and authentication, login and roles                       </li>
    </ul>

    <h3>Optional topics</h3>

    <ul>
    <li>LightSwitch, Silverlight, and Azure (cloud)                                 </li>
    <li>XML/SOAP web services                                                       </li>
    <li>XML support in .NET (brief)                                                 </li>
    <li>Writing multithreaded applications                                          </li>
    <li>Mobile technologies (probably only very brief discussion of the limitations)</li>
    <li>Content Management Systems (CMS), portals etc.</li>
    </ul>
    </div>
</asp:Content>

