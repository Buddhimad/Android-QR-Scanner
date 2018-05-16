package com.example.dell.qrscanner;

/**
 * Created by Dell on 17/06/17.
 */

public class Item {
    private String resourcetype;
    private String description;
    private String additionalinfo;



    public Item() {
    }

    public Item(String resourcetype, String description, String additionalinfo) {
        this.resourcetype = resourcetype;
        this.description = description;
        this.additionalinfo = additionalinfo;
    }

    public String getResourcetype() {
        return resourcetype;
    }

    public void setResourcetype(String resourcetype) {
        this.resourcetype = resourcetype;
    }

    public String getDescription() {
        return description;
    }

    public void setDescription(String description) {
        this.description = description;
    }

    public String getAdditionalinfo() {
        return additionalinfo;
    }

    public void setAdditionalinfo(String additionalinfo) {
        this.additionalinfo = additionalinfo;
    }
}
