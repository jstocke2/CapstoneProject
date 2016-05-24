//Configuration is the default settings and seed for a database based on WorkflowRestfulContext
namespace WorkflowRestful.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WorkflowRestful.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WorkflowRestful.Models.WorkflowRestfulContext>
    {
		//Configures default settings
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = false;
        }

		//Adds test data on new creation of a database
        protected override void Seed(WorkflowRestful.Models.WorkflowRestfulContext context)
        {


            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new WorkflowRestfulContext()));
            /*
            var user = new ApplicationUser()
            {
                UserName = "SuperPowerUser",
                Email = "someguy@mymail.com",
                EmailConfirmed = true,
                FirstName = "unknown",
                LastName = "guy",
                Level = 1,
                JoinDate = DateTime.Now.AddYears(-3)
            };

            manager.Create(user, "MySuperP@ssword!");
            */






            // Added a really long blog text passed by copy paste
            context.Documents.AddOrUpdate(x => x.Id,
                new Document() { Id = 1, },
                new Document() { Id = 2, },
                new Document() { Id = 3, }
                );
            context.Sections.AddOrUpdate(x => x.Id,
                new Section()
                {
                    Id = 1,
                    Text = @"I want to start with a story from the Onion. Because really, shouldn’t every talk start with a story from the Onion? This is from earlier this year.

The headline reads: Nation Shudders At Large Block Of Uninterrupted Text.

“Unable to rest their eyes on a colorful photograph or boldface heading that could be easily skimmed and forgotten, Americans collectively recoiled Monday when confronted with a solid block of uninterrupted text.

“Dumbfounded citizens from Maine to California gazed helplessly at the frightening chunk of print, unsure of what to do next.

“Without an illustration, chart, or embedded YouTube video to ease them in, millions were frozen in place, terrified by the sight of one long, unbroken string of English words.

” ‘It demands so much of my time and concentration,’ said Chicago resident Dale Huza, who was confronted by the confusing mound of words early Monday afternoon. ‘This large block of text, it expects me to figure everything out on my own, and I hate it.’ ”

This is a sign of how rough the outlook sometimes seems for our culture of reading and writing.

In fact, every generation fears the death of literacy at the hands of some new media technology. And yet I’m here to share some optimism. After long existence as a confirmed cynic who shared the general belief in our imminent cultural doom, I felt an unfamiliar sensation 15 years ago when the Internet came over the horizon: I found myself becoming excited and hopeful.

When I looked at the Internet I saw a medium that involves a huge amount of reading. Sure, a lot of it is presented in a highly decorated or distracting form. But a lot of it is in large blocks of uninterrupted text, too!

And there’s something even more significant: The Web isn’t just inspiring a lot of reading. it has also opened the opportunity for a stunning amount of new writing.

When I was growing up in the 1960s and 70s, the chief fear on behalf of literary culture was that television was going to destroy it. What if we were becoming a nation of passive, glassy-eyed couch potatoes — mindless consumers of numbing video entertainment?

To some extent, that happened. Yet we survived! And then something came along that challenged TV. The Web was a two-way medium. Each consumer was also a potential creator or contributor in a way that never happened, couldn’t happen, with television. That’s a huge transformation of our media landscape, And we’re still just getting our heads around it.

So this is the National Day on Writing. I confess I didn’t know there was such a thing till I got this invitation. I’m delighted there is. But it’s an odd construction: “Day *on* writing.” It sort of sounds like those old ads that went, “This is your brain on drugs.”

Think about it: What is “your brain on writing” — or even “our world on writing”? That’s what I’m going to talk about today.

So this Day on Writing is a great thing. I admit, when I first heard it, I thought it was “day *of* writing.” You know: What are we doing here? We should all be writing, right now! Of course, the only way to be a writer is to write frequently, regularly — ideally, daily.

You could always do this, long before there was any such thing as a blog. You could keep a diary or a notebook or a commonplace book. but you couldn’t do it in public, for an audience. Now pretty much anyone can do that. And that’s changed our world in some big ways — some welcome, some distressing.

When I titled my book “Say Everything” I don’t think I realized quite what I was getting into. It turns out to be a really interesting title.

First of all, I promise I will not even attempt to say everything myself today. I’ll talk for maybe 30, 35 minutes, and then open it up for more of a conversation — which is very much the spirit of this topic, anyway.

Pretty soon after I started working on this book I realized that the title was sort of a taunt to myself. Say everything? Saying everything is a writer’s dream. It’s what you think you’ll get to do when you write a book. Get it all between covers! Then you learn that a book ends up feeling really short. And you never get to say more than a fraction of what you want.

The title also turned out to be problematic, because everyone, from my first radio interviewer on, gets it wrong. They say “Say *Anything*.” So don’t worry about it if you do, too. I don’t mind — it’s OK. I’m used to it. But my advice is, don’t give your book a title that’s just a little different from a popular old movie’s name.

I chose the title because it seems to touch on so much of what’s exciting and what’s threatening, too, about blogging and all the other changes that we call, collectively, the digital revolution. “Say everything”: the phrase suggests the thrill of the universal project the Web sometimes seems to be, in which everyone gets to contribute to a vast collective conversation and pool of knowledge. “Say everything” also raises all kinds of questions about this new world. If we say everything, how will we have time to listen? And, “Aren’t some things better left unsaid?” So these are some of the things I’m going to look at today.

Now, a little about the book itself. SAY EVERYTHING tells the story of blogging. Where did this thing come from? Who got it going, and what were their stories? So it’s a kind of contemporary history. I get two reactions when I say that: One group of people, in the technology industry, thinks blogging is now old hat. It’s over. They’ll say, “Blogging? That’s SO 1999!” They’ve already moved on. The other group, which I think is bigger than the first group, says: History? Blogging? What history? It’s so new!

In fact, blogging by that name is now a decade old, and websites that were really blogs in all but name have been around since roughly the mid ’90s. There’s a lot of history — a lot of stories — tales of what happens when people get the chance to say everything they want to in public. I think these stories have a lot to teach us about how to navigate the opportunities and pitfalls of life online.

The culture of Silicon Valley, the tech industry and the Web tends to have a very short memory. And even though the story of how blogging began is a recent one, it’s not that well known. I wrote “Say Everything” because I thought it would be good to get this story down while it’s still fresh. And I was lucky — I’d watched a lot of it first hand.

I built my first website in 1994. And I want to take you back to those days, the early days of the Web. Have any of you seen a video that was circulating a while back called “Medieval Help Desk”? Look it up when you have a chance. This is the one where the medieval monk in Scandinavia is freaked out about this new thing called a “book.” He’s used to scrolls! Books are a weird new interface. He has to ask a helpdesk guy to explain to him how to open it, how to turn pages, and so on. He’s afraid the text will disappear when he closes the covers.

It’s a reminder that every technology we take for granted today was once forbidding and unfamiliar. The Web was the same way at first.

So back then I was the technology editor at Salon.com. My job was to find and assign stories about the Web and computing. We needed one story a week at first — later, we really cranked it up to one story a day. We’d take that story and edit it and illustrate it and publish it with a certain amount of loving care. And people liked it — we did good work — but we could only do so much.

There were a bunch of other websites that I found myself returning to over and over during the course of my day. Because every time I returned to them, they seemed to have something new. These sites didn’t put a lot of time and effort into each story. In fact, they didn’t really publish stories — they posted items. Some of these sites were produced by professionals; others were one-man shows, amateur efforts. They all shared some traits: they tended to be written in a casual, personal voice. they linked a lot. And they didn’t have a “lead story” or “top story.” Each time they posted something new, it went at the top of the page."


                    
                , title = "second"},
                new Section() { Id = 2, Text = "This is the second String Much much shorter", title = "third" },
                new Section() { Id = 3, Text = "This is the third and last test row", title = "fourth"});
            context.Subsections.AddOrUpdate(x => x.Id,
            new Subsection() { Id = 1, Text = "First Test Subsection" },
            new Subsection() { Id = 2, Text = "This is the Second Subsection"},
            new Subsection() { Id = 3, Text = "This is the last Subsection"});
            context.Templates.AddOrUpdate(x => x.Id,
            new Models.Template() { Id = 1, FontId = 2, IndentSpacing = 10, ParagraphSpacing = 10, LineSpacing = 2 },
            new Models.Template() { Id = 2, FontId = 2, IndentSpacing = 10 , ParagraphSpacing = 10, LineSpacing = 2 });
            context.Revisions.AddOrUpdate(x => x.RevisionNumber,
            new Models.Revision() { RevisionNumber = 242});
            







            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
