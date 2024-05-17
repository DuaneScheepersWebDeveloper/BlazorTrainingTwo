console.log("Javascript is working");

function BlazorDownloadFile(filename, byteBase64) {
    console.log("Function working");

    var link = document.createElement('a');
    link.download = filename;
    link.href = "data:application/octet-stream;base64," + byteBase64;
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
}

function focusElement(element) {
    // Focus on the first input field of the new row
    element.focus();
}