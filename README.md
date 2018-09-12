# RemarkFS

FSharp Markdown Slide Creation Tool based on [Remark](https://github.com/gnab/remark)

## Prerequisites

- [Mono](https://www.mono-project.com/download/stable/)
- [Fue](https://github.com/Dzoukr/Fue)
- [Fsharp.Formatting](http://fsprojects.github.io/FSharp.Formatting/)
- [Paket](https://fsprojects.github.io/Paket/)
- [Remark](https://github.com/gnab/remark)

## Install

```bash
mono .paket/paket.exe install
```

## Usage


### Create Presentation Content

Create a new file called `helloworld.md` in the `src` directory

```markdown
# Hello World

---

# Agenda

1. Introduction
2. Deep-dive
3. ...

---

# Introduction
```

### Build Presentations

In the console enter 

```bash
fsharpi app.fsx
```

### See Presentation

Once the script is done running, check the `public` folder and you should see a file called `hello-world.html`. Open it in the browser of your choice and the following content should display.

![](sample.png)

## Configuration

By default, `Markdown` files are stored in the `src` directory and `Remark` presentations are stored in the `public` directory. To change this, edit the `app.config.json` properties to match the folder of your choosing.



