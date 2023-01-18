using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParcelBackend.DTOs;
using ParcelBackend.Models;

namespace ParcelBackend.Controllers;

[ApiController]
[Route("api/parcel")]

public class ParcelController : ControllerBase
{
    private readonly DatabaseContext _db;
    public ParcelController(DatabaseContext context)
    {
        _db = context;
    }

    [HttpGet("getparcels")]
    public IActionResult GetParcels()
    {
       var Parcels =  _db.Parcels.ToList();

        return Ok(Parcels);
    }

    [HttpPost("add")]
    public IActionResult Add(Parcel parcel)
    {
        _db.Parcels.Add(new Models.Parcel { parcelId =parcel.parcelId, parcelCity = parcel.parcelCity, parcelCounty = parcel.parcelCounty, parcelDistrict = parcel.parcelDistrict });
        _db.SaveChanges();
        return Ok();
    }

    [HttpPost("delete")]
    public IActionResult Delete(int? id)
    {
        var parcel = _db.Parcels.Find(id);
        if (parcel == null)
        {
            return NotFound();
        }

        _db.Parcels.Remove(parcel);
        _db.SaveChanges();
        return Ok();
    }

    [HttpPost("update")]
    public IActionResult Update(int? id, string pC, string pCo, string pD)
    {
        
        if (ModelState.IsValid)
        {
            _db.Parcels.Where(x => id == x.parcelId).First().parcelCity = pC;
            _db.Parcels.Where(x => id == x.parcelId).First().parcelCounty = pCo;
            _db.Parcels.Where(x => id == x.parcelId).First().parcelDistrict = pD;
            _db.SaveChanges();
            return Ok();
        }
        return BadRequest();

    }
}

