using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

[ApiController]
public abstract class CrudControllerBase<TEntity, TDto> : ControllerBase
    where TEntity : class, new()
{
    private readonly List<TEntity> _entities;
    private readonly Func<TEntity, int> _getId;
    private readonly Action<TEntity, int> _setId;
    private readonly Action<TEntity, TDto> _applyDto;
    private int _nextId = 1;

    protected CrudControllerBase(
        List<TEntity> entities,
        Func<TEntity, int> getId,
        Action<TEntity, int> setId,
        Action<TEntity, TDto> applyDto)
    {
        _entities = entities;
        _getId = getId;
        _setId = setId;
        _applyDto = applyDto;
    }

    [HttpGet]
    public IActionResult GetAll() => Ok(_entities);

    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        var entity = _entities.FirstOrDefault(e => _getId(e) == id);
        return entity is null ? NotFound() : Ok(entity);
    }

    [HttpPost]
    public IActionResult Create([FromBody] TDto request)
    {
        var entity = new TEntity();
        _setId(entity, _nextId++);
        _applyDto(entity, request);
        _entities.Add(entity);
        return Created($"/{ControllerContext.ActionDescriptor.AttributeRouteInfo?.Template?.Replace("[controller]", ControllerContext.ActionDescriptor.ControllerName.ToLower())}/{_getId(entity)}", entity);
    }

    [HttpPut("{id:int}")]
    public IActionResult Update(int id, [FromBody] TDto request)
    {
        var entity = _entities.FirstOrDefault(e => _getId(e) == id);
        if (entity is null)
        {
            return NotFound();
        }

        _applyDto(entity, request);
        return Ok(entity);
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        var entity = _entities.FirstOrDefault(e => _getId(e) == id);
        if (entity is null)
        {
            return NotFound();
        }

        _entities.Remove(entity);
        return NoContent();
    }
}
