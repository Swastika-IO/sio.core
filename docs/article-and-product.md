# Writing Articles and Products

Articles are entries that display in reverse order on your home page. Articles usually have comments fields beneath them and are included in your site's RSS feed.

To write an article:

1. Log in to your Swastika I/O Core CMS Administration Panel (Dashboard).
2. Click the 'Articles' tab.
3. Click the 'Create Article' sub-tab.
4. Start filling in the blanks: enter your article title in the upper field, and enter your article body content in the main article editing box below it.
5. As needed, select a category, add tags, and make other selections from the sections below the article. (Each of these sections is explained below.)
6. When you are ready, click **Publish**.

# Descriptions of Article Fields

## Title/Headline Box
The title of your article. You can use any phrases, words or characters. Avoid using the same title twice as that will cause problems. You can use commas, aarticlerophes, quotes, hyphens/dashes and other typical symbols in the article like "My Site - Here's Lookin' at You, Kid". Swastika I/O Core CMS will then clean it up to generate a user-friendly and URL-valid name of the article (also called the "article slug") to compose the permalink for the article.

# Excerpt 
A summary or brief teaser of your article featured on the front page of your site as well as on the category, archives, and search non-single article pages. Note that the Excerpt does not usually appear by default. It only appears in your article if you have modified the template file listing the article to use `the_excerpt()` instead of `the_content()` to display the Excerpt instead of the full content of a article. If so, Swastika I/O Core CMS will automatically use as the Excerpt the first 55 words of your article content or the content before the `<!--more-->` quicktag. If you use the "Excerpt" field when editing the article, this will be used no matter what. For more information, see Excerpt.

## Body Copy Box
The blank box where you enter your writing, links, links to images, and any information you want to display on your site. You can use either the Visual or the Text view to compose your articles. For more on the Text view, see the section below, Visual Versus Text View.