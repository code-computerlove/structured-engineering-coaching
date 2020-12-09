# Atomic design and clean CSS

## Goals

Understanding of:

## Content

## Design

Print -> Web -> Responsive/ adaptive

### Works best in 800x600

90s - Everyone used browsers full screen at 800x600 and later 1024x768 with at least 65,536 colours. Slicing up tables was the order of the day.

| Bit depth | # colours      |                 |
| --------- | -------------- | --------------- |
| 1         | 2              | Black and white |
| 2         | 4              | CGA             |
| 3         | 8              | ZX Spectrum     |
| 4         | 16             | EGA/ VGA        |
| 5         | 32             | Original Amiga  |
| 8         | 256            | VGA/ Super VGA  |
| 15        | 32,768         | High color      |
| 16        | 65,536         | High color      |
| 24        | 16,777,216     | True color      |
| 30        | 1.073 billion  | Deep color      |
| 36        | 68.71 billion  |                 |
| 48        | 281.5 trillion | Photoshop       |

| Standard | Aspect ratio | Width | Height |
| -------- | ------------ | ----- | ------ |
| SVGA     | 4:3          | 800   | 600    |
| XGA      | 4:3          | 1024  | 768    |
| WXGA     | 16:9         | 1280  | 720    |
| WXGA     | 16:10        | 1280  | 800    |
| SXGA     | 5:4          | 1280  | 1024   |
| HD       | ≈16:9        | 1360  | 768    |
| HD       | ≈16:9        | 1366  | 768    |
| WXGA+    | 16:10        | 1440  | 900    |
| HD+      | 16:9         | 1600  | 900    |
| WSXGA+   | 16:10        | 1680  | 1050   |
| FHD      | 16:9         | 1920  | 1080   |
| WUXGA    | 16:10        | 1920  | 1200   |
| QWXGA    | 16:9         | 2048  | 1152   |
| QHD      | 16:9         | 2560  | 1440   |
| 4K UHD   | 16:9         | 3840  | 2160   |

We're way past "best in 800x600"!

### Responsive websites

Automatically adjust for different screen sizes and viewports.

Responsive websites respond to the size of the browser at any given point. No matter what the browser width may be, the site adjusts its layout (and perhaps functionality) in a way that is optimized to the screen.

### Adaptive websites

Adaptive websites adapt to the width of the browser at a specific points. In other words, the website is only concerned about the browser being a specific width, at which point it adapts the layout.

## Design systems

> We’re not designing pages, we’re designing systems of components.
>
> -- Stephen Hay.

Colour, typography, grids, texture, shape, form etc.

Patterns in user flow, content strategy, copy, and tone of voice.

To create a cohesive feel.

## Atomic design

> Atomic design is a methodology for creating design systems.
>
> -- Brad Frost

> Atomic design gives us the ability to traverse from abstract to concrete.
>
> -- Brad Frost

### Atoms

Atoms are the basic building blocks of matter. Applied to web interfaces, atoms are our HTML tags, such as a form label, an input or a button.

Atoms can also include more abstract elements like color palettes, fonts and even more invisible aspects of an interface like animations.

Like atoms in nature they’re fairly abstract and often not terribly useful on their own. However, they’re good as a reference in the context of a pattern library as you can see all your global styles laid out at a glance.

### Molecules

Molecules are groups of atoms bonded together and are the smallest fundamental units of a compound. These molecules take on their own properties and serve as the backbone of our design systems.

For example, a form label, input or button aren’t too useful by themselves, but combine them together as a form and now they can actually do something together.

Building up to molecules from atoms encourages a “do one thing and do it well” mentality. While molecules can be complex, as a rule of thumb they are relatively simple combinations of atoms built for reuse.

### Organisms

Molecules give us some building blocks to work with, and we can now combine them together to form organisms. Organisms are groups of molecules joined together to form a relatively complex, distinct section of an interface.

We’re starting to get increasingly concrete. A client might not be terribly interested in the molecules of a design system, but with organisms we can see the final interface beginning to take shape.

Organisms can consist of similar and/or different molecule types. For example, a masthead organism might consist of diverse components like a logo, primary navigation, search form, and list of social media channels. But a “product grid” organism might consist of the same molecule (possibly containing a product image, product title and price) repeated over and over again.

Building up from molecules to organisms encourages creating standalone, portable, reusable components.

### Templates

At the template stage, we break our chemistry analogy to get into language that makes more sense to our clients and our final output. Templates consist mostly of groups of organisms stitched together to form pages. It’s here where we start to see the design coming together and start seeing things like layout in action.

Templates are very concrete and provide context to all these relatively abstract molecules and organisms. Templates are also where clients start seeing the final design in place. In my experience working with this methodology, templates begin their life as HTML wireframes, but over time increase fidelity to ultimately become the final deliverable.

### Pages

Pages are specific instances of templates. Here, placeholder content is replaced with real representative content to give an accurate depiction of what a user will ultimately see.

The page stage is essential as it’s where we test the effectiveness of the design system. Viewing everything in context allows us to loop back to modify our molecules, organisms, and templates to better address the real context of the design.

Pages are also the place to test variations in templates. For example, you might want to articulate what a headline containing 40 characters looks like, but also demonstrate what 340 characters looks like. What does it look like when a user has one item in their shopping cart versus 10 items with a discount code applied? Again, these specific instances influence how we loop back through and construct our system.

### Why atomic design

Atomic design provides a clear methodology for crafting design systems. Clients and team members are able to better appreciate the concept of design systems by actually seeing the steps laid out in front of them.

Atomic design gives us the ability to traverse from abstract to concrete. Because of this, we can create systems that promote consistency and scalability while simultaneously showing things in their final context. And by assembling rather than deconstructing, we’re crafting a system right out of the gate instead of cherry picking patterns after the fact.

## A problem with CSS

The slow slide into a ball of mud.

Programming by coincidence.

Need to keep CSS small, clear, concise and easy to edit.

Treat CSS the same way you'd treat any part of the code base. Clean code.

## Block, Element, Modifier methodology (BEM)

Developed at Yandex, its goal is to help developers better understand the relationship between the HTML and CSS in a given project.

Blocks
Elements
Modifiers

Metaphor - hand = block, element = finger and modifier = index finger

Inverted triangle CSS.
Most selectors for blocks -> Least selectors for modifiers.

## CSS in JS

Styled components rather than CSS modules.
The future?
