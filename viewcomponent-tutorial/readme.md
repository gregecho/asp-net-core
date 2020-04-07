# View components

View components are similar to partial views, but they're much more powerful. View components don't use model binding, and only depend on the data provided when calling into it.

A view component class can be created by any of the following:

- Deriving from ViewComponent
- Decorating a class with the [ViewComponent] attribute, or deriving from a class with the [ViewComponent] attribute
- Creating a class where the name ends with the suffix ViewComponent

`NOTE: A view component never directly handles a request. Typically, a view component initializes a model and passes it to a view by calling the View method.`

## View search path

The runtime searches for the view in the following paths:

- /Views/{Controller Name}/Components/{View Component Name}/{View Name}
- /Views/Shared/Components/{View Component Name}/{View Name}
- /Pages/Shared/Components/{View Component Name}/{View Name}

## Invoking a view component

```c#
@await Component.InvokeAsync("Name of view component", {Anonymous Type Containing Parameters})
```

## Invoking a view component as a Tag Helper

```C#
<vc:priority-list max-priority="2" is-done="false">
</vc:priority-list>
```

To use a view component as a Tag Helper, register the assembly containing the view component using the @addTagHelper directive. If your view component is in an assembly called MyWebApp, add the following directive to the _ViewImports.cshtml file:

```c#
@addTagHelper *, MyWebApp
```

## Invoking a view component directly from a controller
View components are typically invoked from a view, but you can invoke them directly from a controller method. 

```C#
public IActionResult IndexVC()
{
    return ViewComponent("PriorityList", new { maxPriority = 3, isDone = false });
}
```

Reference:  [Managing DbContext the right way with Entity Framework 6: an in-depth guide](https://docs.microsoft.com/en-us/aspnet/core/mvc/views/view-components?view=aspnetcore-3.1)
